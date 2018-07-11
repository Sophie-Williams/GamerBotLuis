using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace GamerBotLuis.Dialogs
{
    [LuisModel(modelID: "de5a093d-b90d-46e1-817e-63d9244745d8 ", subscriptionKey: "931486fbce2e45ddb5a32c33c8db8341")]
    [Serializable]
    public class GamerBotDialogLuis : LuisDialog<string>
    {
        [LuisIntent("None")]
        private async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Lo siento pero no estoy programado para estas opciones. ");
            await Task.Delay(2000);
            await context.PostAsync("En que más te puedo ayudar?");
        }

        [LuisIntent("DarBienvenida")]
        private async Task DarBienvenida(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Bienvenido User, estoy programado para jugar al Piedra, Papel, Tijeras. Tanto el clasico como el extendido");
            await ElejirJuego(context,result);
        }

        [LuisIntent("ElejirJuego")]
        private async Task ElejirJuego(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("¿A que tipo de juego quieres jugar?");
        }
        private async Task Play5Duels(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            if (!finishedDuel)
            {
                if (!playing)
                {
                    Attachment typeOfGame = GetTypeOfGame();
                    var reply = context.MakeMessage();
                    reply.Attachments.Add(typeOfGame);
                    await context.PostAsync(reply);

                    playing = true;
                }
                game = await GetHandCardGame(argument);
                Type classic = typeof(ClassicRockPaperScissorsGame);
                if (game != null)
                {
                    if (game.GetType() == classic)
                    {
                        await ControlClassicGame(game, context, argument);
                    }
                    else
                    {
                        await ControlExtendedClassicGame(game, context, argument);
                    }
                }
            }
        }

        private Attachment GetTypeOfGame()
        {
            var gameCard = new ThumbnailCard
            {
                Title = "Choose the type of Game that you want to play:",
                Subtitle = "",
                Buttons = new List<CardAction>
                {
                    new CardAction (ActionTypes.PostBack, "ClassicGame", value: "ClassicGame"),
                    new CardAction (ActionTypes.PostBack, "ExtendedGame", value: "ExtendedGame" ),
                }
            };

            return gameCard.ToAttachment();
        }

       /* private async Task<IRockPaperScissorsGame> GetHandCardGame(IAwaitable<IMessageActivity> result)
        {
            var r = await result;
            switch (r.Text)
            {
                case "ClassicGame":
                    game = new ClassicRockPaperScissorsGame();
                    break;
                case "ExtendedGame":
                    game = new ExtendedGame();
                    break;
            }
            return game;
        }/*

        [LuisIntent("ElejirMano")]
        private async Task ElejirMano(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("¿Con que tipo de juego de mano quieres jugar?");
        }
    }
}