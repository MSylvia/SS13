// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_Green : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "green";
			this.icon_state = "green";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_Green ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Color_Green( this );
			new Obj_Item_Clothing_Under_Color_Green( this );
			new Obj_Item_Clothing_Under_Color_Green( this );
			new Obj_Item_Clothing_Shoes_Black( this );
			new Obj_Item_Clothing_Shoes_Black( this );
			new Obj_Item_Clothing_Shoes_Black( this );
			this.AddToProfiler();
			return;
		}

	}

}