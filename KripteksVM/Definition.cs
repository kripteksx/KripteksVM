using System;

namespace SignalRServer
{
	public class MessageBase
	{
		public MessageBase()
		{
			CommandName = "";
		}

		public MessageBase(string commandName)
		{
			CommandName = commandName;
		}

		public string CommandName;
	}

	public class GetUserLIst: MessageBase
	{
		public string ConnectionID;

		public GetUserLIst():
			base("GetUserList")
		{ }

		public GetUserLIst(string connectionID):
			base("GetUserList")
		{
			ConnectionID = connectionID;
		}
	}

	public class ReturnUserList:MessageBase
	{
		public ReturnUserList():
			base("ReturnUserList")
		{

		}

		public ReturnUserList(UserData[] userDataList):
			base("ReturnUserList")
		{
			UserDataList = userDataList;
		}

		public UserData[] UserDataList;
	}

	public class CloseData : MessageBase
	{
		public string ConnectionID;
		public string UserName;

		public CloseData() :
			base("CloseData")
		{
		}

		public CloseData(string connectionID, string userName)
			: base("CloseData")
		{
			ConnectionID = connectionID;
			UserName = userName;
		}
	}

	public class LoginData : MessageBase
	{
		public string ConnectionID;
		public string UserName;

		public LoginData() :
			base("LoginData")
		{
			UserName = "";
		}

		public LoginData(string connectionID, string userName)
			: base("LoginData")
		{
			ConnectionID = connectionID;
			UserName = userName;
		}
	}

	public class RequestInfo : MessageBase
	{
		public RequestInfo()
			: base("RequestInfo")
		{
		}

		public RequestInfo(string connectionID)
			: base("RequestInfo")
		{
			ConnectionID = connectionID;
		}

		public string ConnectionID;
	}

	public class TalkWord : MessageBase
	{
		public string Word;
		
		public TalkWord()
			: base("TalkWord")
		{
		}

		public TalkWord(string word)
			:base("TalkWord")
		{
			Word = word;
		}
	}

	public class UserData : MessageBase
	{
		public string ConnectionID;
		public string UserName;

		public UserData()
			:base("UserData")
		{
		}

		public UserData(string connectionID,string userName)
			: base("UserData")
		{
			ConnectionID = connectionID;
			UserName = userName;
		}

	}

	public class ErrorMessage : MessageBase
	{
		public string Message;

		public ErrorMessage() :
			base("ErrorMessage")
		{
		}

		public ErrorMessage(string szMessage)
			: base("ErrorMessage")
		{
			Message = szMessage;
		}
	}

}