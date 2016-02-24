// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Flaming : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hits = 5;
			this.heavy = true;
			this.meteorsound = "sound/effects/bamf.ogg";
			this.meteordrop = typeof(Obj_Item_Weapon_Ore_Plasma);
			this.icon_state = "flaming";
		}

		public Obj_Effect_Meteor_Flaming ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override void meteor_effect( bool? sound = null ) {
			base.meteor_effect( this.heavy );
			GlobalFuncs.explosion( this.loc, 1, 2, 3, 4, 0, false, 5 );
			return;
		}

	}

}