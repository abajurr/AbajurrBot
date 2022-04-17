namespace AbajurrBot.Core.Utils.Constants
{
    public static class StringConstants
    {
        public struct Server
        {
            public const string GetServerCommand = "server";
            public const string GetServerCommandDescription = "Gets information about the server on discord-infra";

            public const string GetServerResponseTitle = "Server Information";
            public const string GetServerResponseDescription = "This is the latest server configuration on discord-infra";

            public const string ApplyCommand = "apply";
            public const string ApplyCommandDescription = "Apply configurations listed on infra-discord to the server";
        }

        public struct Health
        {
            public const string PingCommand = "ping";
            public const string PingCommandDescription = "Sends a ping to check bot health";

            public const string PingResponse = "Pong!";
        }
    }
}
