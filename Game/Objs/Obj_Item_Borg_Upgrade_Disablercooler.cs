// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Disablercooler : Obj_Item_Borg_Upgrade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.require_module = true;
			this.module_type = typeof(Obj_Item_Weapon_RobotModule_Security);
			this.origin_tech = "engineering=4;powerstorage=4";
			this.icon_state = "cyborg_upgrade3";
		}

		public Obj_Item_Borg_Upgrade_Disablercooler ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob )]
		public override bool f_action( Mob_Living_Silicon_Robot R = null ) {
			dynamic T = null;

			
			if ( base.f_action( R ) ) {
				return false;
			}
			T = Lang13.FindIn( typeof(Obj_Item_Weapon_Gun_Energy_Disabler_Cyborg), R.module.modules );

			if ( !Lang13.Bool( T ) ) {
				Task13.User.WriteMsg( "<span class='notice'>There's no disabler in this unit!</span>" );
				return false;
			}

			if ( T.charge_delay <= 2 ) {
				R.WriteMsg( "<span class='notice'>A cooling unit is already installed!</span>" );
				Task13.User.WriteMsg( "<span class='notice'>There's no room for another cooling unit!</span>" );
				return false;
			}
			T.charge_delay = Num13.MaxInt( 2, T.charge_delay - 4 );
			return true;
		}

	}

}