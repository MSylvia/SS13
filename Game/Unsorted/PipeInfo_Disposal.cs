// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class PipeInfo_Disposal : PipeInfo {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.categoryId = true;
			this.icon = "icons/obj/atmospherics/pipes/disposal.dmi";
			this.icon_state = "meterX";
		}

		// Function from file: RPD.dm
		public PipeInfo_Disposal ( int pid = 0, int? dt = null, int? dt_ = null ) : base( pid, dt, dt_ ) {
			this.id = pid;
			this.icon_state = GlobalVars.disposalpipeID2State[pid + 1];
			this.dir = 2;
			this.dirtype = dt;

			if ( pid < 6 || pid > 8 ) {
				this.icon_state = "con" + this.icon_state;
			}
			return;
		}

		// Function from file: RPD.dm
		public override string Render( dynamic dispenser = null, dynamic label = null ) {
			return new Txt( "<li><a href='?src=" ).Ref( dispenser ).str( ";dmake=" ).item( this.id ).str( ";type=" ).item( this.dirtype ).str( "'>" ).item( label ).str( "</a></li>" ).ToString();
		}

	}

}