// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Armor_Reactive : Obj_Item_Clothing_Suit_Armor {

		public bool active = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "reactiveoff";
			this.blood_overlay_type = "armor";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.action_button_name = "Toggle Armor";
			this.unacidable = true;
			this.hit_reaction_chance = 50;
			this.icon_state = "reactiveoff";
		}

		public Obj_Item_Clothing_Suit_Armor_Reactive ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: armor.dm
		public override double emp_act( int severity = 0 ) {
			this.active = false;
			this.icon_state = "reactiveoff";
			this.item_state = "reactiveoff";
			base.emp_act( severity );
			return 0;
		}

		// Function from file: armor.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.active = !this.active;

			if ( this.active ) {
				user.WriteMsg( "<span class='notice'>" + this + " is now active.</span>" );
				this.icon_state = "reactive";
				this.item_state = "reactive";
			} else {
				user.WriteMsg( "<span class='notice'>" + this + " is now inactive.</span>" );
				this.icon_state = "reactiveoff";
				this.item_state = "reactiveoff";
				this.add_fingerprint( user );
			}
			return null;
		}

	}

}