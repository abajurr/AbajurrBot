namespace AbajurrBot.Core.Utils.Constants
{
    public struct Strings
    {
        public struct Server
        {
            public const string Command = "server";
            public const string CommandDescription = "Gets information about the server on discord-infra";

            public const string MessageTitle = "Server Information";
            public const string MessageDescription = "This is the latest server configuration on discord-infra";
        }

        public struct Health
        {
            public const string Command = "ping";
            public const string CommandDescription = "Sends a ping to check bot health";
            public const string CommandResponse = "Pong!";
        }
    }
}
