// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Pumpkin : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hits = 10;
			this.heavy = true;
			this.dropamt = 1;
			this.icon = "icons/obj/meteor_spooky.dmi";
			this.icon_state = "pumpkin";
		}

		// Function from file: meteors.dm
		public Obj_Effect_Meteor_Pumpkin ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.meteordrop = Rand13.Pick(new object [] { typeof(Obj_Item_Clothing_Head_Hardhat_Pumpkinhead), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Pumpkin) });
			this.meteorsound = Rand13.Pick(new object [] { "sound/hallucinations/im_here1.ogg", "sound/hallucinations/im_here2.ogg" });
			return;
		}

	}

}