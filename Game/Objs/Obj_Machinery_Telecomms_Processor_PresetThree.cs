// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Processor_PresetThree : Obj_Machinery_Telecomms_Processor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Processor 3";
			this.network = "tcommsat";
			this.autolinkers = new ByTable(new object [] { "processor3" });
		}

		public Obj_Machinery_Telecomms_Processor_PresetThree ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}