// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_SyndieKit_Chemical : Obj_Item_Weapon_Storage_Box_SyndieKit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.storage_slots = 14;
		}

		// Function from file: uplink_kits.dm
		public Obj_Item_Weapon_Storage_Box_SyndieKit_Chemical ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Polonium( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Venom( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Neurotoxin2( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Formaldehyde( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Cyanide( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Histamine( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Initropidril( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Pancuronium( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_SodiumThiopental( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Coniine( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Curare( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Amanitin( this );
			new Obj_Item_Weapon_ReagentContainers_Syringe( this );
			return;
		}

	}

}