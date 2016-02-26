// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Hydroponics_Soil : Obj_Machinery_Hydroponics {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.unwrenchable = false;
			this.icon_state = "soil";
		}

		public Obj_Machinery_Hydroponics_Soil ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: hydroponics.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Shovel ) {
				user.WriteMsg( "<span class='notice'>You clear up " + this + "!</span>" );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: hydroponics.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			double t_growthstate = 0;

			this.overlays.Cut();
			this.UpdateDescription();

			if ( this.planted ) {
				
				if ( this.dead ) {
					this.overlays.Add( new Image( "icons/obj/hydroponics/growing.dmi", null, "" + this.myseed.species + "-dead" ) );
				} else if ( this.harvest ) {
					
					if ( Convert.ToInt32( this.myseed.plant_type ) == 2 ) {
						this.overlays.Add( new Image( "icons/obj/hydroponics/growing.dmi", null, "" + this.myseed.species + "-grow" + this.myseed.growthstages ) );
					} else {
						this.overlays.Add( new Image( "icons/obj/hydroponics/growing.dmi", null, "" + this.myseed.species + "-harvest" ) );
					}
				} else if ( this.age < Convert.ToDouble( this.myseed.maturation ) ) {
					t_growthstate = this.age / Convert.ToDouble( this.myseed.maturation ) * this.myseed.growthstages;
					this.overlays.Add( new Image( "icons/obj/hydroponics/growing.dmi", null, "" + this.myseed.species + "-grow" + Num13.Floor( t_growthstate ) ) );
					this.lastproduce = this.age;
				} else {
					this.overlays.Add( new Image( "icons/obj/hydroponics/growing.dmi", null, "" + this.myseed.species + "-grow" + this.myseed.growthstages ) );
				}
			}

			if ( this.myseed is Obj_Item_Seeds_Glowshroom ) {
				this.SetLuminosity( Num13.Floor( Convert.ToDouble( this.myseed.potency / 10 ) ) );
			} else {
				this.SetLuminosity( 0 );
			}
			return false;
		}

	}

}