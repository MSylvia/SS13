// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Shadowcloak : Obj_Item_Device {

		public Mob user = null;
		public int charge = 300;
		public int max_charge = 300;
		public bool on = false;
		public int old_alpha = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "utility";
			this.slot_flags = 512;
			this.attack_verb = new ByTable(new object [] { "whipped", "lashed", "disciplined" });
			this.action_button_name = "Toggle Cloaker";
			this.icon = "icons/obj/clothing/belts.dmi";
			this.icon_state = "utilitybelt";
		}

		public Obj_Item_Device_Shadowcloak ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: traitordevices.dm
		public override int? process( dynamic seconds = null ) {
			dynamic T = null;
			dynamic lumcount = null;

			
			if ( this.user.get_item_by_slot( 6 ) != this ) {
				this.Deactivate();
				return null;
			}
			T = GlobalFuncs.get_turf( this );

			if ( this.on ) {
				lumcount = ((Tile)T).get_lumcount();

				if ( Convert.ToDouble( lumcount ) > 3 ) {
					this.charge = Num13.MaxInt( 0, this.charge - 25 );
				} else {
					this.charge = Num13.MinInt( this.max_charge, this.charge + 50 );
				}
				Icon13.Animate( new ByTable().Set( 1, this.user ).Set( "alpha", Num13.MaxInt( 0, Num13.MinInt( 255 - this.charge, 255 ) ) ).Set( "time", 10 ) );
			}
			return null;
		}

		// Function from file: traitordevices.dm
		public override bool dropped( dynamic user = null ) {
			
			if ( Lang13.Bool( user ) && ((Mob)user).get_item_by_slot( 6 ) != this ) {
				this.Deactivate();
			}
			return false;
		}

		// Function from file: traitordevices.dm
		public void Deactivate(  ) {
			this.user.WriteMsg( "<span class='notice'>You deactivate " + this + ".</span>" );
			GlobalVars.SSobj.processing.Remove( this );

			if ( this.user != null ) {
				this.user.alpha = this.old_alpha;
			}
			this.on = false;
			this.user = null;
			return;
		}

		// Function from file: traitordevices.dm
		public void Activate( Mob user = null ) {
			
			if ( !( user != null ) ) {
				return;
			}
			user.WriteMsg( "<span class='notice'>You activate " + this + ".</span>" );
			this.user = user;
			GlobalVars.SSobj.processing.Or( this );
			this.old_alpha = user.alpha;
			this.on = true;
			return;
		}

		// Function from file: traitordevices.dm
		public override void ui_action_click(  ) {
			
			if ( Task13.User.get_item_by_slot( 6 ) == this ) {
				
				if ( !this.on ) {
					this.Activate( Task13.User );
				} else {
					this.Deactivate();
				}
			}
			return;
		}

	}

}