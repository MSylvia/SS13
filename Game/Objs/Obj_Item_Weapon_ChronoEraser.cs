// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ChronoEraser : Obj_Item_Weapon {

		public Obj_Item_Weapon_Gun_Energy_ChronoGun PA = null;
		public ByTable erased_minds = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "backpack";
			this.w_class = 4;
			this.slot_flags = 1024;
			this.slowdown = 1;
			this.action_button_name = "Equip/Unequip TED Gun";
			this.icon = "icons/obj/chronos.dmi";
			this.icon_state = "chronobackpack";
		}

		public Obj_Item_Weapon_ChronoEraser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: chrono_eraser.dm
		public override void ui_action_click(  ) {
			Ent_Static user = null;

			user = this.loc;

			if ( user is Mob_Living_Carbon && ((dynamic)user).back == this ) {
				
				if ( this.PA != null ) {
					GlobalFuncs.qdel( this.PA );
				} else {
					this.PA = new Obj_Item_Weapon_Gun_Energy_ChronoGun( this );
					((dynamic)user).put_in_hands( this.PA );
				}
			}
			return;
		}

		// Function from file: chrono_eraser.dm
		public override dynamic Destroy(  ) {
			this.dropped();
			return base.Destroy();
		}

		// Function from file: chrono_eraser.dm
		public override bool dropped( dynamic user = null ) {
			
			if ( this.PA != null ) {
				GlobalFuncs.qdel( this.PA );
			}
			return false;
		}

		// Function from file: chrono_eraser.dm
		public void pass_mind( dynamic M = null ) {
			this.erased_minds.Add( M );
			return;
		}

	}

}