require('dotenv').config()

const Discord = require('discord.js');
const client = new Discord.Client();


client.on('ready', () => {
  console.log(`Bot is ready!`)
})

// events are structured liket this
// client.on("message", (message) => {
//     // This code runs when the event is triggered
//   });

client.on('message', msg => {
    if (msg.content === 'foo') {
      msg.reply('bar!')
    }
  })
  

  client.login(process.env.BOT_TOKEN)