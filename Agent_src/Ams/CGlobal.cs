using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections;

namespace AgentCom
{

    public enum QueueType : byte
    {
        CPQueue = 0,
        MTNQueue = 1,
        ADMQueue = 2,
        InternalMessage = 0xff
    }
    public enum OperatorTypeSetMessage : byte
    {
        Answer = 0x01,
        Hold = 0x02,
        Transfer = 0x03,
        WaitOperator = 0x04,
        Disconnect = 0x05,
        Offhook = 0x06,
        DialDigit = 0x07,
        TrunkDial = 0x08,
        OperatorLogin = 0x09,
        OperatorLoggOff = 0xa,
        NightMode = 0x0b,
        DayMode = 0x0c,
        RevertBack = 0x0d,
        AddSpeedDial = 0x0e,
        DelSpeedDial = 0x0f,
        LiveCheckCmd = 0x10,
        LiveCheckReply = 0x11,
        AccessTalkParty = 0x12,
        RedialLastNumber = 0x13,
        OperatorDiscNumber = 0x14





    }
    public enum AdminPortType : byte
    {
        LineTypeSet = 1,
        LineTypeGet = 33,
        DigitalTrunkTypeSet = 3,
        DigitalTrunkTypeGet = 35,
        AnalogTrunkTypeSet = 2,
        AnalogTrunkTypeGet = 34,
        ShargeingType = 10,
        OperatorType = 12,
        AlarmMcuType = 21,
        AlarmLcuType = 20,
        AlarmLineType = 1,
        AlarmTrunkType = 3,
        AlarmSS7Type = 4,

        SystemCheckingType = 30,
        ReportAdmType = 45,
        //LineTracingType=40,
        //DigitalTrunkTracingType=41,
        TracingType = 40,
        SystemDuplicationType = 50,
        LoopBackTestType = 55,
        MaliciousType = 60,
        FileTransferType = 70,
        AlarmPanelTypeSet = 80,
        SystemStatus = 90,
        StatusType = 100,
        FromSerialPortInputBuffer = 0xff,
        FromSerialPortOutputBuffer = 0xfe,
        ToggleManagement = 0xfd,
        ConnectionExist = 0xfc,
        //ResetTypeSet =200,
        MTNLineType = 200,
        MTNDigitalTrunkType = 201,
        MTNAnalogTrunkType = 202,
        MTNLCUType = 203,
        MTNRCUType = 204,
        MTNSlotType = 205,
        MTNShelfType = 206,
        MTNRackType = 207,
        MTNMCUTyp = 208,

        //MCUType =251,
        SS7SignalingType = 252,//4
        V52SignalingType = 253
    }
    public enum PortType: byte
    {
        AnalogTrunkType =2,
        PriL3Type =17
    }
    public enum TrunkInOut: byte
    {
            Incomming = 0,
            Outgoing = 1,
            BothWay = 2
    }
    public class CGlobal
    {

        public enum State : byte
        {
            Idle = 0,
            WfDail = 1,
            WfAnswer = 2,
            Answer = 3,
            Hold =4,
            Trnasfer = 5,
            WFOffhook_Ack = 6,
            WforPDigit = 7 

        }

        public enum OperatorCallType : byte
        {
            Internal = 0,
            Extenal ,
            National


        }
       
        public static IPAddress ipRemote;
        public static String ServerIpStr;
        public static String ServerPort;
        public static String AgentNumber;
        public static String AgentPhone;
        public static bool OperatorLoginFlag;
        public static bool operatorDayNightFlag;
        public static bool btnApplyPressed;
        public static string dayNightNumber;
        public static string addPhonenumber;
        public static string DBServerName;

        public static string phoneBookName;
        public static string phoneBookNumber;
        public static string phoneBookType;
        public static string phoneBookJob;
        public static string phoneBookDescription;
        public static bool FocousFlag;
        public static byte operatorCallType;
        public static byte operatorDigitCount;
        public static int phonebookIndex;
        public static int phonebookAutoIndex;
        public static string phonebookType;
        public static string phonebookName;
        public static string phonebookNumber;
        public static string phonebookDescription;
        public static string speedIndex;
        public static string speedPhone; 
        public static string speedName;
        public static string phoneBookSearchPhone;
        public static string operatorRedialPhoneNumber;
        public static bool frmCompanyLoginFlag = false;
        public static bool pickupCall = false;
        public static bool soundState = true;
        public static string lastInteralTxMessage;

        public static Queue iReceivedPackets = new Queue();
        public static Queue ReceivedPackets = new Queue();
        public static Queue SendPackets = new Queue();
        public static Queue iSendPackets = new Queue();
        public static Queue StatusPackets = new Queue();
        public static InternalNetwork inNetSocket;
        public static bool mySQLStatus;

    }
}
