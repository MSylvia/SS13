// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Panacea : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Can be used while unconscious.";
			this.chemical_cost = 20;
			this.dna_cost = 1;
			this.req_stat = 1;
		}

		public Obj_Effect_ProcHolder_Changeling_Panacea ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: panacea.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			dynamic egg = null;
			Mob C = null;
			Disease D = null;

			user.WriteMsg( "<span class='notice'>We begin cleansing impurities from our form.</span>" );
			egg = user.getorgan( typeof(Obj_Item_Organ_Internal_BodyEgg) );

			if ( Lang13.Bool( egg ) ) {
				((Obj_Item_Organ_Internal)egg).Remove( user );

				if ( user is Mob_Living_Carbon ) {
					C = user;
					((Mob_Living_Carbon)C).vomit( 0 );
				}
				egg.loc = GlobalFuncs.get_turf( user );
			}
			user.reagents.add_reagent( "mutadone", 10 );
			user.reagents.add_reagent( "potass_iodide", 10 );
			user.reagents.add_reagent( "charcoal", 20 );

			foreach (dynamic _a in Lang13.Enumerate( user.viruses, typeof(Disease) )) {
				D = _a;
				
				D.cure();
			}
			GlobalFuncs.feedback_add_details( "changeling_powers", "AP" );
			return 1;
		}

	}

}