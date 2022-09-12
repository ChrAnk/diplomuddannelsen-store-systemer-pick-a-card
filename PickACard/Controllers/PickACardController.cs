using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace PickACard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PickACardController : ControllerBase
    {
        private string Suit = "", Value = "", Shorthand = "";

        private int CardIndex = Random.Shared.Next(0, 54);

        [HttpGet("/")]

        public object Get()
        {
            if(CardIndex > 51)
            {
                Suit = "Joker";
                Value = "Joker";
                Shorthand = "JJ";
            }
            else
            {
                switch (CardIndex % 4)
                {
                    case 0:
                        Suit = "Spades";
                        Shorthand = "S";
                        break;
                    case 1:
                        Suit = "Hearts";
                        Shorthand = "H";
                        break;
                    case 2:
                        Suit = "Diamonds";
                        Shorthand = "D";
                        break;
                    case 3:
                        Suit = "Clubs";
                        Shorthand = "C";
                        break;
                }

                switch (CardIndex % 13)
                {
                    case 0:
                        Value = "Ace";
                        Shorthand += "A";
                        break;
                    case 10:
                        Value = "Jack";
                        Shorthand += "J";
                        break;
                    case 11:
                        Value = "Queen";
                        Shorthand += "Q";
                        break;
                    case 12:
                        Value = "King";
                        Shorthand += "K";
                        break;
                    default:
                        Value = "" + ((CardIndex % 13) + 1);
                        Shorthand += Value;
                        break;
                }
            }

            return new PickACard
            {
                Suit = Suit,
                Value = Value,
                Shorthand = Shorthand
            };
        }
    }
}