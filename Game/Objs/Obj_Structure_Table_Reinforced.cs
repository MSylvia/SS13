// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Table_Reinforced : Obj_Structure_Table {

		public int status = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.buildstack = typeof(Obj_Item_Stack_Sheet_Plasteel);
			this.canSmoothWith = new ByTable(new object [] { typeof(Obj_Structure_Table_Reinforced), typeof(Obj_Structure_Table) });
			this.icon = "icons/obj/smooth_structures/reinforced_table.dmi";
			this.icon_state = "r_table";
		}

		public Obj_Structure_Table_Reinforced ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tables_racks.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			base.attack_hulk( hulk, true );

			if ( Rand13.PercentChance( 75 ) ) {
				GlobalFuncs.playsound( this, "sound/effects/meteorimpact.ogg", 100, 1 );
				hulk.WriteMsg( "<span class='notice'>You kick " + this + " into pieces.</span>" );
				hulk.say( Rand13.Pick(new object [] { ";RAAAAAAAARGH!", ";HNNNNNNNNNGGGGGGH!", ";GWAAAAAAAARRRHHH!", "NNNNNNNNGGGGGGGGHH!", ";AAAAAAARRRGH!" }) );
				this.table_destroy( 1 );
			} else {
				GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
				hulk.WriteMsg( "<span class='notice'>You kick " + this + ".</span>" );
			}
			return true;
		}

		// Function from file: tables_racks.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.attack_hand( a );
			return null;
		}

		// Function from file: tables_racks.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic WT = null;

			
			if ( A is Obj_Item_Weapon_Weldingtool ) {
				WT = A;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
					
					if ( this.status == 2 ) {
						user.WriteMsg( "<span class='notice'>You start weakening the reinforced table...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );

						if ( GlobalFuncs.do_after( user, 50 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
								return null;
							}
							user.WriteMsg( "<span class='notice'>You weaken the table.</span>" );
							this.status = 1;
						}
					} else {
						user.WriteMsg( "<span class='notice'>You start strengthening the reinforced table...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );

						if ( GlobalFuncs.do_after( user, 50 / A.toolspeed, null, this ) ) {
							
							if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
								return null;
							}
							user.WriteMsg( "<span class='notice'>You strengthen the table.</span>" );
							this.status = 2;
						}
					}
					return null;
				}
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}