using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DmxFramework.Fixtures;
using DmxFramework.Scene;

namespace DmxFramework.Keyboard
{
    public delegate  void OnKeyPressedHandler(System.Windows.Forms.KeyEventArgs pKey);

    public class KeyBord
    {
        public event OnKeyPressedHandler OnKeyPressed = null;
        
        private Hashtable mHashTable;
        private List<Hotkey> mKeyList;

        private bool mEnabled = true;

        private Hotkey mKeyStep = null;
        
        public KeyBord()
        {
            mHashTable = new Hashtable();
            mKeyList = new List<Hotkey>();
        }

        public Hotkey KeyStepr
        {
            get { return mKeyStep; }
            set { mKeyStep = value; }
        }


        public void PressKey(System.Windows.Forms.KeyEventArgs pKey)
        {
            if (OnKeyPressed != null)
                OnKeyPressed(pKey);

            if (!mEnabled)
                return;

            try
            {
                
                Hotkey key = (Hotkey)mHashTable[(int)pKey.KeyValue];
                if (key != null)
                    key.Press();
            }
            catch{}
            
        }

        public void KeyUp(System.Windows.Forms.KeyEventArgs pKey)
        {
            if (!mEnabled)
                return;

            try
            {
                Hotkey key = (Hotkey)mHashTable[(int)pKey.KeyValue];
                if (key != null)
                    key.KeyUp();
            }
            catch { }

        }

        public Hotkey AddKey(System.Windows.Forms.KeyEventArgs pKey)
        {
            return AddKey(pKey.KeyCode.ToString(), pKey.KeyValue);
        }

        public Hotkey AddKey(string pKeyCode, int pKeyValue)
        {
            if (mHashTable.ContainsKey(pKeyValue))
                return (Hotkey)mHashTable[pKeyValue];

            Hotkey key = new Hotkey(pKeyCode, pKeyValue);
            mHashTable.Add(pKeyValue, key);
            mKeyList.Add(key);
            return key;
        }

        public Hotkey GetKey(int pKeyValue)
        {
            if (mHashTable.ContainsKey(pKeyValue))
                return (Hotkey)mHashTable[pKeyValue];

            return null;
        }

        public void Remove(Hotkey pKey)
        {
            mHashTable.Remove(pKey.KeyValue);
            mKeyList.Remove(pKey);
        }

        public List<Hotkey> KeyList
        {
            get { return mKeyList; }
        }


        public void LoadXml(Fixture pFixture,XmlNode pNode)
        {
            //bool IsSceneAction = true;
            foreach (XmlNode node in pNode.ChildNodes)
            {
                /*DmxFramework.Scene.Scene sce = GetSceneInFixture(pFixture, node.Attributes["Path"].InnerText);
                if (sce == null)
                    continue;
                */
                Action action = null;

                //On récupere l'objet Key
                Hotkey key = AddKey(node.Attributes["Code"].InnerText, Convert.ToInt32(node.Attributes["Value"].InnerText));

                if (node.Attributes["isKeyStep"] != null)
                {
                    key.IsKeyStep = true;
                    key.Actions = null;
                    mKeyStep = key;
                    continue;
                }


                
                /*IsSceneAction = true;
                if (node.Attributes["IsSceneAction"] != null && Convert.ToBoolean(node.Attributes["IsSceneAction"].InnerText) == false)
                    IsSceneAction = false;*/

               
                action = GetActionInFixture(pFixture, node.Attributes["Path"].InnerText);
                
                if (action == null)
                    continue;

                action.Path = node.Attributes["Path"].InnerText;
                
                 if (node.Attributes["StopOnKeyUp"] != null)
                    action.StopOnKeyUp = Convert.ToBoolean(node.Attributes["StopOnKeyUp"].InnerText);

                
                               
                //on assigne l'action à la touche ...
                key.Actions.Add(action);

            }
        }

        public XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement KeyElement;
            XmlAttribute KeyAttribute;
            XmlElement KeyBordElement = pDocument.CreateElement("Keyboard");

            foreach (Hotkey key in mKeyList)
            {
                if (key.IsKeyStep)
                {
                    KeyElement = pDocument.CreateElement("Key");

                    KeyAttribute = pDocument.CreateAttribute("Code");
                    KeyAttribute.InnerText = key.KeyCode;
                    KeyElement.Attributes.Append(KeyAttribute);

                    KeyAttribute = pDocument.CreateAttribute("Value");
                    KeyAttribute.InnerText = key.KeyValue + "";
                    KeyElement.Attributes.Append(KeyAttribute);

                    KeyAttribute = pDocument.CreateAttribute("isKeyStep");
                    KeyAttribute.InnerText = "true";
                    KeyElement.Attributes.Append(KeyAttribute);

                    KeyBordElement.AppendChild(KeyElement);
                }
                else
                {
                    foreach (Action action in key.Actions)
                    {

                        KeyElement = pDocument.CreateElement("Key");

                        KeyAttribute = pDocument.CreateAttribute("Code");
                        KeyAttribute.InnerText = key.KeyCode;
                        KeyElement.Attributes.Append(KeyAttribute);

                        KeyAttribute = pDocument.CreateAttribute("Value");
                        KeyAttribute.InnerText = key.KeyValue + "";
                        KeyElement.Attributes.Append(KeyAttribute);

                        if (key.IsKeyStep)
                        {
                            KeyAttribute = pDocument.CreateAttribute("isKeyStep");
                            KeyAttribute.InnerText = "true";
                            KeyElement.Attributes.Append(KeyAttribute);
                        }
                        else
                        {

                            /*KeyAttribute = pDocument.CreateAttribute("IsSceneAction");
                            KeyAttribute.InnerText = true.ToString();
                            KeyElement.Attributes.Append(KeyAttribute);*/

                            KeyAttribute = pDocument.CreateAttribute("Path");
                            KeyAttribute.InnerText = action.Path;
                            KeyElement.Attributes.Append(KeyAttribute);

                            KeyAttribute = pDocument.CreateAttribute("StopOnKeyUp");
                            KeyAttribute.InnerText = action.StopOnKeyUp.ToString();
                            KeyElement.Attributes.Append(KeyAttribute);
                        }
                        KeyBordElement.AppendChild(KeyElement);
                    }
                }
            }

            return KeyBordElement;
        }

        Action GetActionInFixture(Fixture pFixture, string pPath)
        {
            string NewPath = pPath.Substring(pPath.IndexOf('/')+1);

            string[] Splitter = NewPath.Split(new char[] { '/' });

            if(Splitter.Length>3)   
            {

                if (pFixture is VirtualFixture)
                {
                    foreach (Fixture fix in ((VirtualFixture)pFixture).SubFixture)
                    {
                        if (fix.Name == Splitter[0])
                            return GetActionInFixture(fix, NewPath);
                    }
                }
            }
            else if (Splitter.Length == 3 && Splitter[0]=="Scene") 
            {
                foreach(Scene.Scene scene in pFixture.Manager.Scenes)
                {
                    if (scene.Category == Splitter[1] && scene.Name == Splitter[2])
                        return new Action(scene);
                }
            }
            else if (Splitter.Length == 3 && Splitter[0] == "Button")
            {
                foreach (Channels.Channel chan in pFixture.Channels)
                {
                    if (chan.Name != Splitter[1])
                        continue;

                    foreach(DmxFramework.Channels.DmxValue val in chan.DmxValues)
                    {
                        if (val.Text == Splitter[2])
                            return new Action(chan, val);
                    }
                }
            }
            return null;

        }
    }
}
