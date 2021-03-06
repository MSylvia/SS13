// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Unstableslimetoxin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Unstable Mutation Toxin";
			this.id = "unstablemutationtoxin";
			this.description = "An unstable and unpredictable corruptive toxin produced by slimes.";
			this.color = "#5EFF3B";
			this.metabolization_rate = Double.PositiveInfinity;
		}

		// Function from file: other_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			ByTable possible_morphs = null;
			dynamic type = null;
			dynamic S = null;
			dynamic mutation = null;

			base.on_mob_life( (object)(M) );
			M.WriteMsg( "<span class='warning'><b>You crumple in agony as your flesh wildly morphs into new forms!</b></span>" );
			((Ent_Static)M).visible_message( "<b>" + M + "</b> falls to the ground and screams as their skin bubbles and froths!" );
			((Mob)M).Weaken( 3 );
			Task13.Schedule( 30, (Task13.Closure)(() => {
				
				if ( !Lang13.Bool( M ) || Lang13.Bool( GlobalFuncs.qdeleted( M ) ) ) {
					return;
				}
				possible_morphs = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Species) ) - typeof(Species) )) {
					type = _a;
					
					S = type;

					if ( Lang13.Bool( Lang13.Initial( S, "blacklisted" ) ) ) {
						continue;
					}
					possible_morphs.Add( S );
				}
				mutation = Rand13.PickFromTable( possible_morphs );

				if ( Rand13.PercentChance( 90 ) && Lang13.Bool( mutation ) && M.dna.species != typeof(Species_Golem) && M.dna.species != typeof(Species_Golem_Adamantine) ) {
					M.WriteMsg( "<span class='danger'>The pain subsides. You feel... different.</span>" );
					((Mob)M).set_species( mutation );

					if ( mutation.id == "slime" ) {
						M.faction |= "slime";
					} else {
						M.faction -= "slime";
					}
				} else {
					M.WriteMsg( "<span class='danger'>The pain vanishes suddenly. You feel no different.</span>" );
				}
				return;
			}));
			return true;
		}

	}

}