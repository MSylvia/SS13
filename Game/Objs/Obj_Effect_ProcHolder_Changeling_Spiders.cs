// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Spiders : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "The spiders are thoughtless creatures, and may attack their creators when fully grown. Requires at least 5 DNA absorptions.";
			this.chemical_cost = 45;
			this.dna_cost = 1;
			this.req_dna = 5;
		}

		public Obj_Effect_ProcHolder_Changeling_Spiders ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spiders.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			int? i = null;
			Obj_Effect_Spider_Spiderling S = null;

			i = null;
			i = 0;

			while (( i ??0) < 2) {
				S = new Obj_Effect_Spider_Spiderling( user.loc );
				S.grow_as = typeof(Mob_Living_SimpleAnimal_Hostile_Poison_GiantSpider_Hunter);
				i++;
			}
			GlobalFuncs.feedback_add_details( "changeling_powers", "SI" );
			return 1;
		}

	}

}