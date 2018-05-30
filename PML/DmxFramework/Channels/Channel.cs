using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DmxFramework.Fixtures;
	
namespace DmxFramework.Channels
{
    #region enum definition

    /// <summary>
    /// Origine of a dmx change
    /// </summary>
    public enum ChangeOrigin
    {
        User,
        Scene,
        AutoMode,
        Sound,
        Derivated
    }
    
    /// <summary>
    /// Function of channel
    /// </summary>
    public enum ChannelFunction
    {
        /// <summary>
        /// Pan channel
        /// </summary>
        Pan,

        /// <summary>
        /// Tilt channel
        /// </summary>
        Tilt,

        /// <summary>
        /// btn
        /// </summary>
        Btn,

        /// <summary>
        /// basic Channel
        /// </summary>
        Basic,

        /// <summary>
        /// basic Channel
        /// </summary>
        List
    }

    /// <summary>
    /// TYpe of channel
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// Virtual dmx channel : used for groups, ...)
        /// </summary>
        Virtual, 

        /// <summary>
        /// Real dmx channel : Value are send to the fixtures
        /// </summary>
        Real
    }

    #endregion

    #region delegate definition

    /// <summary>
    /// Handler for Channel onValue changed events
    /// </summary>
    /// <param name="pChannel">Channel object</param>
    /// <param name="pValue">pValue</param>
    public delegate void OnValueChangedHandler(Channel pChannel, int pValue);

    /// <summary>
    /// Handler for Channel onValue changed events
    /// </summary>
    /// <param name="pChannel">Channel object</param>
    /// <param name="pValue">pValue</param>
    public delegate void OnForcedStateChangedHandler(Channel pChannel, bool pIsForced);

    #endregion

    /// <summary>
    /// Abstract class representating a channel
    /// </summary>
    public abstract class Channel
    {
        #region members
        
        protected ChannelFunction mFunction;
        protected ChannelType mType;
        protected ArrayList mDmxValues;
        protected string mName;
        protected int mCurrentValue;
        protected bool mIsForced;
        protected bool mIsInverted;
        protected int mNumber;
        protected int mValue;
        protected bool mLocked = false;
        protected bool mInvertedInAutoMode = false;
        protected int mMaxInAutoMode = 255;
        protected int mMinInAutoMode = 0;
        protected bool mIsInSceneMode = false;


        private Fixture mFixture;

        //for btn type only
        protected int mRowCount;
        protected int mColumnCount;


        #endregion


        #region events

        /// <summary>
        /// Event triggered on the changement of value if the channel
        /// </summary>
        public event OnValueChangedHandler OnValueChanged;

        /// <summary>
        /// Event triggered when the forced state of the channel changed
        /// </summary>
        public event OnForcedStateChangedHandler OnForcedStateChanged;
        
        #endregion

     
        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Channel(ChannelType pType)
        {
            mType = pType;
            mIsForced = false;
            mDmxValues = null;
            OnValueChanged = null;
            mValue = 0;
        }
        #endregion


        #region properties
       
        /// <summary>
        /// Get all the channel dmx possible values
        /// </summary>
        public ArrayList DmxValues
        { 
            get { return mDmxValues; } 
            set { mDmxValues = value; } 
        }


        /// <summary>
        /// Type of channel (internal, external)
        /// </summary>
        public ChannelType Type
        { get { return mType; } }

        /// <summary>
        /// Function of the channel (pan, tilt, gobo, ...)
        /// </summary>
        public ChannelFunction Function
        { 
            get { return mFunction; } 
            set { mFunction = value; }
        }

        /// <summary>
        /// Name of the channel
        /// </summary>
        public string Name
        { 
            get { return mName; }
            set { mName = value; }
        }


        /// <summary>
        /// Indicates if the channel is forced
        /// </summary>
        public bool IsForced
        { get { return mIsForced; } }

        /// <summary>
        /// Indicates if the channel is inverted
        /// </summary>
        public bool IsInverted
        { 
            get { return mIsInverted; }
            set { mIsInverted = value;} 
        }

        /// <summary>
        /// Channel number
        /// </summary>
        public int Number
        {
            get { return mNumber; }
            set { mNumber = value; }
        }

        /// <summary>
        /// Channel current value
        /// </summary>
        public int Value
        {
            get { return mValue; }
        }

        /// <summary>
        /// For button panel : largeur
        /// </summary>
        public int ColumnCount
        {
            get { return mColumnCount; }
            set { mColumnCount = value; }
        }

        /// <summary>
        /// For button panel : largeur
        /// </summary>
        public int RowCount
        {
            get { return mRowCount; }
            set { mRowCount = value; }
        }

        /// <summary>
        /// Indicate if the fixture is locked
        /// </summary>
        public bool Locked
        {
            get { return mLocked; }
            set { mLocked = value; }
        }

        public bool InvertedInAutoMode
        {
            get { return mInvertedInAutoMode; }
            set { mInvertedInAutoMode = value; }
        }

        public abstract int MaxInAutoMode
        {
            get;
            set;
        }


        public abstract int MinInAutoMode
        {
            get;
            set;
        }


        public bool IsInSceneMode
        {
            get { return mIsInSceneMode; }
            set { mIsInSceneMode = value; }
        }

        public Fixture Fixture
        {
            get { return mFixture; }
            set { mFixture = value; }
        }

        public string Path
        {
            get { return mFixture.Path + "/" + mName; }
        }


        #endregion

        #region public methods

        /// <summary>
        /// set the value of the channel
        /// </summary>
        /// <param name="pValue">Value to set</param>
        public void SetValue(int pValue, ChangeOrigin pOrigin)
        {
            if (this.mIsForced)
                return;



            //if the fixture is locked, only user is allowed to change value
            if (this.mLocked && pOrigin != ChangeOrigin.User)
                return;

            //if the fixture is in scene mode, ignore xhange from beat detection or automatic mode
            if (this.mIsInSceneMode && (pOrigin == ChangeOrigin.AutoMode || pOrigin == ChangeOrigin.Sound))
                return;

            InternalChangeValue(pValue, false, pOrigin);
        }

        /// <summary>
        /// force a value to the channel
        /// </summary>
        /// <param name="pValue">value ....</param>
        public void ForceValue(int pValue, ChangeOrigin pOrigin)
        {
            if (!mIsForced && OnForcedStateChanged != null)
            {
                this.mIsForced = true;
                OnForcedStateChanged(this, true);
            }



            //if the fixture is locked, only user is allowed to change value
            if (this.mLocked && pOrigin != ChangeOrigin.User)
                return;

            this.mIsForced = true;
            InternalChangeValue(pValue, true, pOrigin);
        }

        


        /// <summary>
        /// Unforce the channel
        /// </summary>
        public virtual void UnforceValue()
        {
            if (mIsForced && OnForcedStateChanged != null)
            {
                this.mIsForced = false;
                OnForcedStateChanged(this, false);
            }
            this.mIsForced = false;
        }

        #endregion


        #region protected abstract methods 

        protected abstract void ChangeValue(int pValue, bool pFromForcage, ChangeOrigin pOrigin);

        #endregion


        #region private methods
        private void InternalChangeValue(int pValue, bool pFromForcage, ChangeOrigin pOrigin)
        {
            //security check
            if (pValue < 0 || pValue >= 256)
                throw new Exception("Value out of range");

      

            if (Framework.InvertChannelsInAutoMode)
            {
                if (pOrigin == ChangeOrigin.AutoMode || pOrigin == ChangeOrigin.Sound)
                {
                    if (this.mInvertedInAutoMode)
                        pValue = mMaxInAutoMode + mMinInAutoMode - pValue;
                }
            }
           

            if (this.IsInverted)
                ChangeValue(255 - pValue, pFromForcage, pOrigin);
            else
                ChangeValue(pValue, pFromForcage, pOrigin);

            if (this.OnValueChanged != null && pValue != mValue)
                OnValueChanged(this, pValue);

            mValue = pValue;
        }
        #endregion

        #region protected methods

        protected void TriggerNewForceEvent(bool pForce)
        {
            if (OnForcedStateChanged!=null)
                OnForcedStateChanged(this,pForce);
        }

        protected void LoadButtons(XmlNode pNode, ArrayList pSubFixtures)
        {
            if (mFunction != ChannelFunction.Btn && mFunction != ChannelFunction.List)
                return;

            if (mFunction == ChannelFunction.Btn)
            {
                this.mRowCount = Convert.ToInt32(pNode.Attributes["RowCount"].InnerText);
                this.mColumnCount = Convert.ToInt32(pNode.Attributes["ColumnCount"].InnerText);
            }
            mDmxValues = new ArrayList();

            if (pNode.ChildNodes == null || pNode.ChildNodes.Count == 0)
                return;

            foreach (XmlNode node in pNode.ChildNodes)
            {
                mDmxValues.Add(new DmxValue(node, pSubFixtures));
            }
        }

        #endregion


        #region static methods

        public static ChannelFunction StringToFunction(string pFunction)
        {
            switch (pFunction)
            {
                case "Pan": return ChannelFunction.Pan;
                case "Tilt": return ChannelFunction.Tilt;
                case "Btn": return ChannelFunction.Btn;
                case "Basic": return ChannelFunction.Basic;
                case "List": return ChannelFunction.List;
            }
            return ChannelFunction.Basic;
        }

        #endregion


        public abstract XmlNode Save(XmlDocument pDocument);


        public override string ToString()
        {
            return mName;
        }
    }
}
