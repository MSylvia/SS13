// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Scrying : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throw_speed = 3;
			this.throwforce = 15;
			this.damtype = "fire";
			this.force = 15;
			this.hitsound = "sound/items/welder2.ogg";
			this.icon = "icons/obj/projectiles.dmi";
			this.icon_state = "bluespace";
		}

		public Obj_Item_Weapon_Scrying ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: artefact.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			user.WriteMsg( "<span class='notice'>You can see...everything!</span>" );
			this.visible_message( "<span class='danger'>" + user + " stares into " + this + ", their eyes glazing over.</span>" );
			((Mob)user).ghostize( true );
			return null;
		}

	}

}