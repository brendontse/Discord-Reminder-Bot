const Discord = require('discord.js')
const client = new Discord.Client()

client.on('ready', () => {
  console.log(`Logged in as ${client.user.tag}!`)
})

client.on('message', msg => {
  if (msg.content === 'ping') {
    msg.reply('Pong!')
  }
})

client.login('NjUyNTg4NTU2MjM3Mjc1MTM2.XeqvMw.wZnizpYunDtPjOUVgWj194jp514')