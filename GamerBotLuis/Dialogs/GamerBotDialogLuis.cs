using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GamerBot.Logics;
using GamerBot.Model;
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
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Lo siento pero no estoy programado para estas opciones. ");
            await Task.Delay(2000);
            await context.PostAsync("En que más te puedo ayudar?");
        }

        [LuisIntent("DarBienvenida")]
        public async Task DarBienvenida(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Bienvenido User, estoy programado para jugar al Piedra, Papel, Tijeras. Tanto el clasico como el extendido");
            await ElejirJuego(context, result);
        }

        [LuisIntent("ElejirJuego")]
        public async Task ElejirJuego(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("¿A que tipo de juego quieres jugar?");
        }
    }
}