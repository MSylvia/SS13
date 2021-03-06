// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Cyberimp_Eyes_Thermals_Ling : Obj_Item_Organ_Internal_Cyberimp_Eyes_Thermals {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.eye_color = null;
			this.origin_tech = "biotech=5;magnets=5";
			this.slot = "eye_ling";
			this.aug_message = "You feel a minute twitch in our eyes, and darkness creeps away.";
			this.icon_state = "ling_thermal";
		}

		public Obj_Item_Organ_Internal_Cyberimp_Eyes_Thermals_Ling ( dynamic M = null ) : base( (object)(M) ) {
			
		}

		// Function from file: augmented_eyesight.dm
		public override void Remove( dynamic M = null, bool? special = null ) {
			special = special ?? false;

			dynamic H = null;

			
			if ( this.owner is Mob_Living_Carbon_Human ) {
				H = this.owner;
				H.weakeyes = false;
			}
			base.Remove( (object)(M), special );
			return;
		}

		// Function from file: augmented_eyesight.dm
		public override void Insert( dynamic M = null, int? special = null ) {
			special = special ?? 0;

			dynamic H = null;

			base.Insert( (object)(M), special );

			if ( this.owner is Mob_Living_Carbon_Human ) {
				H = this.owner;
				H.weakeyes = true;
			}
			return;
		}

		// Function from file: augmented_eyesight.dm
		public override double emp_act( int severity = 0 ) {
			return 0;
		}

	}

}