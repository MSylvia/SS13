// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Bombcore_Badmin_Summon_Clown : Obj_Item_Weapon_Bombcore_Badmin_Summon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.summon_path = typeof(Mob_Living_SimpleAnimal_Hostile_Retaliate_Clown);
			this.amt_summon = 100;
		}

		public Obj_Item_Weapon_Bombcore_Badmin_Summon_Clown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicatebomb.dm
		public override void defuse(  ) {
			GlobalFuncs.playsound( this.loc, "sound/misc/sadtrombone.ogg", 50 );
			base.defuse();
			return;
		}

	}

}