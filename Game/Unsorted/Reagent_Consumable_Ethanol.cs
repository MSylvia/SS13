// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Ethanol : Reagent_Consumable {

		public int boozepwr = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ethanol";
			this.id = "ethanol";
			this.description = "A well-known alcohol with a variety of applications.";
			this.color = "#404030";
			this.nutriment_factor = 0;
		}

		// Function from file: alcohol_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( !( M is Mob_Living ) ) {
				return 0;
			}

			if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
				((Mob_Living)M).adjust_fire_stacks( ( reac_volume ??0) / 15 );
			}
			base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			return 0;
		}

		// Function from file: alcohol_reagents.dm
		public override bool reaction_obj( dynamic O = null, double? volume = null ) {
			dynamic paperaffected = null;
			dynamic affectedbook = null;

			
			if ( O is Obj_Item_Weapon_Paper ) {
				paperaffected = O;
				((Obj_Item_Weapon_Paper)paperaffected).clearpaper();
				Task13.User.WriteMsg( "The solution melts away the ink on the paper." );
			}

			if ( O is Obj_Item_Weapon_Book ) {
				
				if ( ( volume ??0) >= 5 ) {
					affectedbook = O;
					affectedbook.dat = null;
					Task13.User.WriteMsg( "The solution melts away the ink on the book." );
				} else {
					Task13.User.WriteMsg( "It wasn't enough..." );
				}
			}
			return false;
		}

		// Function from file: alcohol_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			double drunk_value = 0;

			M.jitteriness = Num13.MaxInt( M.jitteriness - 5, 0 );

			if ( this.current_cycle >= this.boozepwr * 0.5 ) {
				drunk_value = Math.Sqrt( this.volume * 1000 / this.boozepwr );

				if ( this.volume >= this.boozepwr * 0.2 ) {
					
					if ( M.slurring < drunk_value ) {
						M.slurring += 4;
					}
					((Mob)M).Dizzy( drunk_value );
				}

				if ( this.volume >= this.boozepwr * 0.8 ) {
					
					if ( M.confused < drunk_value ) {
						M.confused += 3;
					}
				}

				if ( this.volume >= this.boozepwr * 371 ) {
					((Mob_Living)M).adjustToxLoss( 1 );
				}
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}