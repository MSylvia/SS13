// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Spellbook_Oneuse_Knock : Obj_Item_Weapon_Spellbook_Oneuse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spell = typeof(Obj_Effect_ProcHolder_Spell_AoeTurf_Knock);
			this.spellname = "knock";
			this.icon_state = "bookknock";
		}

		public Obj_Item_Weapon_Spellbook_Oneuse_Knock ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spellbook.dm
		public override void recoil( dynamic user = null ) {
			base.recoil( (object)(user) );
			user.WriteMsg( "<span class='warning'>You're knocked down!</span>" );
			((Mob)user).Weaken( 20 );
			return;
		}

	}

}