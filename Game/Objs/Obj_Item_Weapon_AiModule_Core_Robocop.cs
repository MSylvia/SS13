// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Core_Robocop : Obj_Item_Weapon_AiModule_Core {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modname = "Robocop";
			this.origin_tech = "programming=4";
			this.laws = new ByTable(new object [] { "Serve the public trust.", "Protect the innocent.", "Uphold the law." });
		}

		public Obj_Item_Weapon_AiModule_Core_Robocop ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}