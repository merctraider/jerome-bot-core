using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord; 
using Newtonsoft.Json;
using JeromeBot; 

namespace JeromeBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        string title;
        string bodyText; 

        [Command("about")]
        public async Task About()
        {
            await Context.Channel.SendMessageAsync("A bot to search and look up writings of the Church Fathers.");
        }

        [Command ("creed")]
        public async Task Creed(string name)
        {
            switch (name)
            {
                case "apostles":
                    title = "The Apostles' Creed";
                    bodyText = "I believe in God, the Father almighty, creator of heaven and earth. I believe in Jesus Christ, God's only Son, our Lord, who was conceived by the Holy Spirit, born of the Virgin Mary, suffered under Pontius Pilate, was crucified, died, and was buried; he descended to the dead. On the third day he rose again; he ascended into heaven, he is seated at the right hand of the Father, and he will come again to judge the living and the dead. I believe in the Holy Spirit, the holy catholic Church, the communion of saints, the forgiveness of sins, the resurrection of the body, and the life everlasting. Amen.";
                    break;

                case "nicene":
                    title = "The Nicene-Constantinopolitan Creed";
                    bodyText = "I believe in one God, the Father Almighty, Maker of Heaven and earth, and of all things visible and invisible. ​ And in one Lord Jesus Christ, the Son of God, the Only-begotten, begotten of the Father before all ages; Light of Light: true God of true God; begotten, not made; of one essence with the Father, by Whom all things were made; Who for us men, and for our salvation, came down from the heavens, and was incarnate of the Holy Spirit and the Virgin Mary, and became man; And was crucified for us under Pontius Pilate, and suffered, and was buried; And arose again on the third day according to the Scriptures; And ascended into the heavens, and sitteth at the right hand of the Father; And shall come again, with glory, to judge both the living and the dead; Whose kingdom shall have no end. ​ And in the Holy Spirit, the Lord, the Giver of Life; Who proceedeth from the Father and the Son; Who with the Father and the Son together is worshipped and glorified; Who spake by the prophets. ​ In One, Holy, Catholic, and Apostolic Church. I confess one baptism for the remission of sins. I look for the resurrection of the dead, And the life of the age to come. Amen.";
                    break;

                case "athanasian":
                    title = "The Athanasian Creed";
                    bodyText = "Full creed here: https://www.ccel.org/creeds/athanasian.creed.html";
                        break; 
            }
                

            var embed = new EmbedBuilder();
            embed.WithTitle(title);
            embed.WithDescription(bodyText);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed.Build());

            
            

        }


        [Command("read")]
        public async Task Read(string title, string contents)
        {
            TextHandler._fileName = title;

            string textTitle = "Error"; 

            if (title == "augustineconfessions")
            {
                textTitle = "The Confessions of St. Augustine " + contents; 
            }

            
            bodyText = TextHandler.GetContents(contents);

            var embed = new EmbedBuilder();
            embed.WithTitle(textTitle);
            embed.WithDescription(bodyText);
            embed.WithColor(new Color(0, 255, 0));
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }


        [Command("filename")]
        public async Task PrintFile()
        {

            await Context.Channel.SendMessageAsync(TextHandler._fileName);
        }

    }
}
