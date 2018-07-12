using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GamerBotLuis.Dialogs
{
    [LuisModel("de5a093d-b90d-46e1-817e-63d9244745d8", "931486fbce2e45ddb5a32c33c8db8341")]

    [Serializable]
    public class GamerDialog : LuisDialog<object>
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
            await context.PostAsync("Bienvenido User, estoy programado para jugar al Piedra, Papel, Tijeras. Tanto el clasico como el extendido, elije a cual quieres jugar:");
        }

        [LuisIntent("ElejirJuego")]
        public async Task ElejirJuego(IDialogContext context, LuisResult result, IAwaitable<IMessageActivity> argument)
        {
            await context.PostAsync("¿Cual es el tipo de juego al que quieres jugar?");
            await Task.Delay(2000);

        }

    }
}