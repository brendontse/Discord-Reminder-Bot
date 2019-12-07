const Discord = require('discord.js')
const client = new Discord.Client()
const config = require("./config.json");

const prefix = "!";

client.on('ready', () => {
  console.log(`Logged in as ${client.user.tag}!`)
})

client.on('message', msg => {
    if (message.content.startsWith(config.prefix + "ping")) {
        message.channel.send("pong!");
    } else
    if (message.content.startsWith(config.prefix + "foo")) {
        message.channel.send("bar!");
})

client.login('config.token')