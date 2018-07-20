using GamerBot.Logics;
using GamerBot.Model;
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
    public class GamerDialog : LuisDialog<IRockPaperScissorsGame>
    {
        public const string INTENT_NONE = "None";
        public const string INTENT_WELCOME = "DarBienvenida";
        public const string INTENT_CHOOSEGAME = "ElegirJuego";
        public const string INTENT_CHOOSEHAND = "ElegirMano";
        public const string INTENT_PLAYGAME = "Jugar";
        public const string INTENT_PLAYREMATCH = "ElegirRevancha";
        public const string INTENT_BYE = "DespedirBot";

        IRockPaperScissorsGame game;
        IAwaitable<IMessageActivity> argumentG;
        HandType hand;
        ExtendedHandType extendedHand;
        HandType winnerHand;
        HandType randomHand;
        Type classic = typeof(ClassicRockPaperScissorsGame);
        Type extended = typeof(ExtendedGame);
        EntityRecommendation handEntity;
        EntityRecommendation extendedHandEntity;
        bool rematching = false;

        [LuisIntent(INTENT_NONE)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Lo siento pero no estoy programado para estas opciones. ");
            await Task.Delay(2000);
            await context.PostAsync("En que más te puedo ayudar?");

        }

        [LuisIntent(INTENT_WELCOME)]
        public async Task DarBienvenida(IDialogContext context, LuisResult result)
        {
            if (result.TryFindEntity("Saludo", out var greeting))
            {
                await context.PostAsync("Estoy programado para jugar al Piedra, Papel, Tijeras.");
                await context.PostAsync("Tanto el clasico como el extendido, dime con cúal quieres jugar.");
            }
        }

        [LuisIntent(INTENT_CHOOSEGAME)]
        public async Task ChoosGame(IDialogContext context, LuisResult result)
        {
            if (result.TryFindEntity("Juego::Clasico", out var classicGameEntity))
            {
                await context.PostAsync("Has elegido el juego clasico");
                game = new ClassicRockPaperScissorsGame();
                await context.PostAsync("Debes elegir un tipo de mano!!");
                await context.PostAsync("Cuál eliges entre estas: Papel, Piedra o Tijeras ");
            }

            if (result.TryFindEntity("Juego::Extendido", out var extGameEntity))
            {
                await context.PostAsync("Has elegido el juego extendido");
                game = new ExtendedGame();
                await context.PostAsync("¿Debes elegir un tipo de mano: Papel, Piedra, Tijeras, Lagarto, Spock !!");
                await Task.Delay(2000);
                await context.PostAsync("¿Cuál eliges?");
            }
        }

        [LuisIntent(INTENT_CHOOSEHAND)]
        public async Task ChooseHandType(IDialogContext context, LuisResult result)
        {
            if (game.GetType() == classic)
            {
                if (result.TryFindEntity("Mano::Piedra", out handEntity))
                {
                    await context.PostAsync("Has elegido Piedra");
                    hand = HandType.Stone;
                }
                else if (result.TryFindEntity("Mano::Papel", out handEntity))
                {
                    await context.PostAsync("Has elegido Papel");
                    hand = HandType.Paper;
                }
                else if (result.TryFindEntity("Mano::Tijeras", out handEntity))
                {
                    await context.PostAsync("Has elegido Tijeras");
                    hand = HandType.Scissors;
                }
            }

            if (game.GetType() == extended)
            {
                if (result.TryFindEntity("Mano::Piedra", out extendedHandEntity))
                {
                    await context.PostAsync("Has elegido Piedra");
                    extendedHand = (ExtendedHandType)HandType.Stone;
                }
                else if (result.TryFindEntity("Mano::Papel", out extendedHandEntity))
                {
                    await context.PostAsync("Has elegido Papel");
                    extendedHand = (ExtendedHandType)HandType.Paper;
                }
                else if (result.TryFindEntity("Mano::Tijeras", out extendedHandEntity))
                {
                    await context.PostAsync("Has elegido Papel");
                    extendedHand = (ExtendedHandType)HandType.Paper;
                }
                else if (result.TryFindEntity("Mano::Lagarto", out extendedHandEntity))
                {
                    await context.PostAsync("Has elegido Lagarto");
                    extendedHand = ExtendedHandType.Lizard;
                }
                else if (result.TryFindEntity("Mano::Spock", out extendedHandEntity))
                {
                    await context.PostAsync("Has elegido Spock");
                    extendedHand = ExtendedHandType.Spock; //TO DO: Change the language of visual studio for doing all on English! Cause Luis can't understand Spock with Spanish.
                }
            }

            await context.PostAsync("Ya elejiste, cuando quieras empezamos a jugar!");
        }

        [LuisIntent(INTENT_PLAYGAME)]
        public async Task PlayGame(IDialogContext context, LuisResult result)
        {
            //if (!rematching) TO DO: Implementation of my rematch option;
            //{
                if (game.GetType() == typeof(ClassicRockPaperScissorsGame))
                {
                    randomHand = RandomHand.GetRandomHand();
                    winnerHand = game.Play(hand, randomHand);
                }
                else if (game.GetType() == typeof(ExtendedGame))
                {
                    randomHand = RandomExtendedHand.GetRandomHand();
                    winnerHand = game.Play(extendedHand, randomHand);
                }
                await context.PostAsync($"Esta es tu mano: {hand.Name.ToString()} y esta la mía: {randomHand.Name.ToString()} ");
                await context.PostAsync($"La mano ganadora es: {winnerHand.Name.ToString()} ");
            //}
            //else if (rematching)
            //{
            //    await PlayRematch(context, result);
            //}
        }

        //[LuisIntent(INTENT_PLAYREMATCH)]
        //public async Task PlayRematch(IDialogContext context, LuisResult result)
        //{
        //    if (result.TryFindEntity("Revancha", out var rematchEntity))
        //    {
        //        await ChooseHandType(context, result);
        //        await PlayGame(context, result);
        //    }
        //}
    }
}