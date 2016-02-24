// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_DestTagger : Obj_Item_Device {

		public double? currTag = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.item_state = "electronic";
			this.flags = 64;
			this.slot_flags = 512;
			this.icon_state = "cargotagger";
		}

		public Obj_Item_Device_DestTagger ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: sortingmachinery.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			double? n = null;

			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["nextTag"] ) ) {
				n = String13.ParseNumber( href_list["nextTag"] );
				this.currTag = n;
			}
			this.openwindow( Task13.User );
			return null;
		}

		// Function from file: sortingmachinery.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.openwindow( user );
			return null;
		}

		// Function from file: sortingmachinery.dm
		public void openwindow( dynamic user = null ) {
			string dat = null;
			int? i = null;

			dat = "<tt><center><h1><b>TagMaster 2.2</b></h1></center>";
			dat += "<table style='width:100%; padding:4px;'><tr>";
			i = null;
			i = 1;

			while (( i ??0) <= GlobalVars.TAGGERLOCATIONS.len) {
				dat += new Txt( "<td><a href='?src=" ).Ref( this ).str( ";nextTag=" ).item( i ).str( "'>" ).item( GlobalVars.TAGGERLOCATIONS[i] ).str( "</a></td>" ).ToString();

				if ( ( i ??0) % 4 == 0 ) {
					dat += "</tr><tr>";
				}
				i++;
			}
			dat += "</tr></table><br>Current Selection: " + ( Lang13.Bool( this.currTag ) ? GlobalVars.TAGGERLOCATIONS[this.currTag] : "None" ) + "</tt>";
			Interface13.Browse( user, dat, "window=destTagScreen;size=450x350" );
			GlobalFuncs.onclose( user, "destTagScreen" );
			return;
		}

	}

}