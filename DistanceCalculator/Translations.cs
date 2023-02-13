using Rocket.API.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculatorPlugin
{
    public partial class DistanceCalculatorPlugin
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {
                "Distance", "[color=#FF0000]{{DistanceCalculator}} [/color] [color=#F3F3F3]Distance:[/color] [color=#3E65FF]{0}[/color]"
            },
            {
                "DistanceToFar", "[color=#FF0000]{{DistanceCalculator}} [/color][color=#F3F3F3]Unable to get the Distance![/color]"
            }
        };
    }
}