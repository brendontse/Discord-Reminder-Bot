0. Create Discord application and declare needed permissions. Discord will generate a client ID and token key.

1. Get bot token from Environment.cs

2. Log in to client using a type of OAuth2 authentication that only needs the token

3. Start connection from local server to Discord API

4. Discord.NET uses .NET's Task-based Asynchronous Pattern (TAP)
Program will start and will immediately jump into async context.

5. Bot now waits until there is a message entered into the channel.

6. 
if (!(message.HasStringPrefix(Environment.prefix, ref argPos))) return;

if the message does not have the prefix, return to current task (wait until new message)

HOWEVER, if it does run task ExecuteCommand

7. ExecuteCommand will then go through and find the command that matches the command entered into the channel

8. Context is EXTREMELY important at this point as users, channel, place, etc. will change depening on the command.

9. Currently making the help command parse through EVERY command and return it as a Embed object, as if a user were sending a message
This allows for better visuallization as well as being able to navigate embed objects using subscribers and emotes to navigate.

10. Lots and lots of unexpected issues with bots. 
Reading it's own messages, not having permissions, SO MANY VARIABLES

but also no CSS

11. Stretch goals. More interactivity, navigating embeds using emotes, incorperating database, deploying on a virtual private server (VPS) or AWS
