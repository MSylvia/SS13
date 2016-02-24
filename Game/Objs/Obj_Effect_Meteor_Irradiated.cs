// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Irradiated : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.heavy = true;
			this.meteordrop = typeof(Obj_Item_Weapon_Ore_Uranium);
			this.icon_state = "glowing";
		}

		public Obj_Effect_Meteor_Irradiated ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override void meteor_effect( bool? sound = null ) {
			base.meteor_effect( this.heavy );
			GlobalFuncs.explosion( this.loc, 0, 0, 4, 3, 0 );
			new Obj_Effect_Decal_Cleanable_Greenglow( GlobalFuncs.get_turf( this ) );
			GlobalFuncs.radiation_pulse( GlobalFuncs.get_turf( this ), 2, 5, 50, true );
			return;
		}

	}

}