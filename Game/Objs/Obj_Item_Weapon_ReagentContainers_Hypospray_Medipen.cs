// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Hypospray_Medipen : Obj_Item_Weapon_ReagentContainers_Hypospray {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "medipen";
			this.amount_per_transfer_from_this = 10;
			this.volume = 10;
			this.ignore_flags = true;
			this.list_reagents = new ByTable().Set( "epinephrine", 10 );
			this.icon_state = "medipen";
		}

		public Obj_Item_Weapon_ReagentContainers_Hypospray_Medipen ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: hypospray.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( this.reagents != null && this.reagents.reagent_list.len != 0 ) {
				Task13.User.WriteMsg( "<span class='notice'>It is currently loaded.</span>" );
			} else {
				Task13.User.WriteMsg( "<span class='notice'>It is spent.</span>" );
			}
			return 0;
		}

		// Function from file: hypospray.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( ( this.reagents.total_volume ??0) > 0 ) {
				this.icon_state = Lang13.Initial( this, "icon_state" );
			} else {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "0";
			}
			return false;
		}

		// Function from file: hypospray.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			dynamic R = null;

			
			if ( !Lang13.Bool( this.reagents.total_volume ) ) {
				user.WriteMsg( "<span class='warning'>" + this + " is empty!</span>" );
				return false;
			}
			base.attack( (object)(M), (object)(user), def_zone );
			this.update_icon();
			Task13.Schedule( 80, (Task13.Closure)(() => {
				
				if ( user is Mob_Living_Silicon_Robot && !Lang13.Bool( this.reagents.total_volume ) ) {
					R = user;

					if ( ((Obj_Item_Weapon_StockParts_Cell)R.cell).use( 100 ) ) {
						this.reagents.add_reagent_list( this.list_reagents );
						this.update_icon();
					}
				}
				return;
			}));
			return false;
		}

	}

}