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

client.on('message', msg => {
if (msg.content === 'ping') {
    msg.reply('Pong!')
}
})

  client.login('NjUyNTg4NTU2MjM3Mjc1MTM2.XesVCg.qXDTvdE8-fTHEX7ccRCntuxeRZ4')