// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Ddrill : Obj_Item_Borg_Upgrade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.require_module = true;
			this.module_type = typeof(Obj_Item_Weapon_RobotModule_Miner);
			this.origin_tech = "engineering=5;materials=5";
			this.icon_state = "cyborg_upgrade3";
		}

		public Obj_Item_Borg_Upgrade_Ddrill ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob )]
		public override bool f_action( Mob_Living_Silicon_Robot R = null ) {
			Obj_Item_Weapon_Pickaxe_Drill_Cyborg D = null;
			Obj_Item_Weapon_Shovel S = null;

			
			if ( base.f_action( R ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( R.module.modules, typeof(Obj_Item_Weapon_Pickaxe_Drill_Cyborg) )) {
				D = _a;
				
				GlobalFuncs.qdel( D );
			}

			foreach (dynamic _b in Lang13.Enumerate( R.module.modules, typeof(Obj_Item_Weapon_Shovel) )) {
				S = _b;
				
				GlobalFuncs.qdel( S );
			}
			R.module.modules.Add( new Obj_Item_Weapon_Pickaxe_Drill_Cyborg_Diamond( R.module ) );
			R.module.rebuild();
			return true;
		}

	}

}