// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Aviatorhelmet : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 25 ).Set( "bullet", 0 ).Set( "laser", 20 ).Set( "energy", 10 ).Set( "bomb", 10 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.item_state = "aviator_helmet";
			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.icon_state = "aviator_helmet";
		}

		public Obj_Item_Clothing_Head_Helmet_Aviatorhelmet ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}