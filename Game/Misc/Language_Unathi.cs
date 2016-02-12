// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Language_Unathi : Language {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sinta'unathi";
			this.desc = "The common language of Moghes, composed of sibilant hisses and rattles. Spoken natively by Unathi.";
			this.speech_verb = "hisses";
			this.ask_verb = "hisses";
			this.exclaim_verb = "roars";
			this.colour = "soghun";
			this.key = "o";
			this.flags = 2;
			this.syllables = new ByTable(new object [] { "ss", "ss", "ss", "ss", "skak", "seeki", "resh", "las", "esi", "kor", "sh" });
		}

	}

}