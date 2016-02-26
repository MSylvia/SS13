// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_EvolutionMenu : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dna_cost = 0;
		}

		public Obj_Effect_ProcHolder_Changeling_EvolutionMenu ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: evolution_menu.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic dat = null;

			base.Topic( href, href_list, (object)(hsrc) );

			if ( !( Task13.User is Mob_Living_Carbon && Task13.User.mind != null && Task13.User.mind.changeling != null ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["P"] ) ) {
				Task13.User.mind.changeling.purchasePower( Task13.User, href_list["P"] );
			} else if ( Lang13.Bool( href_list["readapt"] ) ) {
				Task13.User.mind.changeling.lingRespec( Task13.User );
			}
			dat = this.create_menu( Task13.User.mind.changeling );
			Interface13.Browse( Task13.User, dat, "window=powers;size=600x700" );
			return null;
		}

		// Function from file: evolution_menu.dm
		public dynamic create_menu( Changeling changeling = null ) {
			dynamic dat = null;
			int i = 0;
			dynamic path = null;
			dynamic P = null;
			bool ownsthis = false;
			string color = null;

			dat += "<html><head><title>Changling Evolution Menu</title></head>";
			dat += new Txt( @"

		<head>
			<script type='text/javascript'>

				var locked_tabs = new Array();

				function updateSearch(){


					var filter_text = document.getElementById('filter');
					var filter = filter_text.value.toLowerCase();

					if(complete_list != null && complete_list != """"){
						var mtbl = document.getElementById(""maintable_data_archive"");
						mtbl.innerHTML = complete_list;
					}

					if(filter.value == """"){
						return;
					}else{

						var maintable_data = document.getElementById('maintable_data');
						var ltr = maintable_data.getElementsByTagName(""tr"");
						for ( var i = 0; i < ltr.length; ++i )
						{
							try{
								var tr = ltr[i];
								if(tr.getAttribute(""id"").indexOf(""data"") != 0){
									continue;
								}
								var ltd = tr.getElementsByTagName(""td"");
								var td = ltd[0];
								var lsearch = td.getElementsByTagName(""b"");
								var search = lsearch[0];
								//var inner_span = li.getElementsByTagName(""span"")[1] //Should only ever contain one element.
								//document.write(""<p>""+search.innerText+""<br>""+filter+""<br>""+search.innerText.indexOf(filter))
								if ( search.innerText.toLowerCase().indexOf(filter) == -1 )
								{
									//document.write(""a"");
									//ltr.removeChild(tr);
									td.innerHTML = """";
									i--;
								}
							}catch(err) {   }
						}
					}

					var count = 0;
					var index = -1;
					var debug = document.getElementById(""debug"");

					locked_tabs = new Array();

				}

				function expand(id,name,desc,helptext,power,ownsthis){

					clearAll();

					var span = document.getElementById(id);

					body = ""<table><tr><td>"";

					body += ""</td><td align='center'>"";

					body += ""<font size='2'><b>""+desc+""</b></font> <BR>""

					body += ""<font size='2'><span class='danger'>""+helptext+""</span></font> <BR>""

					if(!ownsthis)
					{
						body += ""<a href='?src=" ).Ref( this ).str( @";P=""+power+""'>Evolve</a>""
					}
					body += ""</td><td align='center'>"";

					body += ""</td></tr></table>"";


					span.innerHTML = body
				}

				function clearAll(){
					var spans = document.getElementsByTagName('span');
					for(var i = 0; i < spans.length; i++){
						var span = spans[i];

						var id = span.getAttribute(""id"");

						if(!(id.indexOf(""item"")==0))
							continue;

						var pass = 1;

						for(var j = 0; j < locked_tabs.length; j++){
							if(locked_tabs[j]==id){
								pass = 0;
								break;
							}
						}

						if(pass != 1)
							continue;




						span.innerHTML = """";
					}
				}

				function addToLocked(id,link_id,notice_span_id){
					var link = document.getElementById(link_id);
					var decision = link.getAttribute(""name"");
					if(decision == ""1""){
						link.setAttribute(""name"",""2"");
					}else{
						link.setAttribute(""name"",""1"");
						removeFromLocked(id,link_id,notice_span_id);
						return;
					}

					var pass = 1;
					for(var j = 0; j < locked_tabs.length; j++){
						if(locked_tabs[j]==id){
							pass = 0;
							break;
						}
					}
					if(!pass)
						return;
					locked_tabs.push(id);
					var notice_span = document.getElementById(notice_span_id);
					notice_span.innerHTML = ""<span class='danger'>Locked</span> "";
					//link.setAttribute(""onClick"",""attempt('""+id+""','""+link_id+""','""+notice_span_id+""');"");
					//document.write(""removeFromLocked('""+id+""','""+link_id+""','""+notice_span_id+""')"");
					//document.write(""aa - ""+link.getAttribute(""onClick""));
				}

				function attempt(ab){
					return ab;
				}

				function removeFromLocked(id,link_id,notice_span_id){
					//document.write(""a"");
					var index = 0;
					var pass = 0;
					for(var j = 0; j < locked_tabs.length; j++){
						if(locked_tabs[j]==id){
							pass = 1;
							index = j;
							break;
						}
					}
					if(!pass)
						return;
					locked_tabs[index] = """";
					var notice_span = document.getElementById(notice_span_id);
					notice_span.innerHTML = """";
					//var link = document.getElementById(link_id);
					//link.setAttribute(""onClick"",""addToLocked('""+id+""','""+link_id+""','""+notice_span_id+""')"");
				}

				function selectTextField(){
					var filter_text = document.getElementById('filter');
					filter_text.focus();
					filter_text.select();
				}

			</script>
		</head>


	" ).ToString();
			dat += "<body onload='selectTextField(); updateSearch();' onkeyup='updateSearch();'>";
			dat += new Txt( @"

		<table width='560' align='center' cellspacing='0' cellpadding='5' id='maintable'>
			<tr id='title_tr'>
				<td align='center'>
					<font size='5'><b>Changeling Evolution Menu</b></font><br>
					Hover over a power to see more information<br>
					Current ability choices remaining: " ).item( changeling.geneticpoints ).str( "<br>\n					By rendering a lifeform to a husk, we gain enough power to alter and adapt our evolutions.<br>\n					(<a href='?src=" ).Ref( this ).str( @";readapt=1'>Readapt</a>)<br>
					<p>
				</td>
			</tr>
			<tr id='search_tr'>
				<td align='center'>
					<b>Search:</b> <input type='text' id='filter' value='' style='width:300px;'>
				</td>
			</tr>
	</table>

	" ).ToString();
			dat += "\n		<span id='maintable_data_archive'>\n		<table width='560' align='center' cellspacing='0' cellpadding='5' id='maintable_data'>";
			i = 1;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.sting_paths )) {
				path = _a;
				
				P = Lang13.Call( path );

				if ( P.dna_cost <= 0 ) {
					continue;
				}
				ownsthis = changeling.has_sting( P );
				color = null;

				if ( ownsthis ) {
					
					if ( i % 2 == 0 ) {
						color = "#d8ebd8";
					} else {
						color = "#c3dec3";
					}
				} else if ( i % 2 == 0 ) {
					color = "#f2f2f2";
				} else {
					color = "#e6e6e6";
				}
				dat += "\n\n			<tr id='data" + i + "' name='" + i + "' onClick=\"addToLocked('item" + i + "','data" + i + "','notice_span" + i + "')\">\n				<td align='center' bgcolor='" + color + "'>\n					<span id='notice_span" + i + "'></span>\n					<a id='link" + i + "'\n					onmouseover='expand(\"item" + i + "\",\"" + P.name + "\",\"" + P.desc + "\",\"" + P.helptext + "\",\"" + P + "\"," + ownsthis + ")'\n					>\n					<b id='search" + i + "'>Evolve " + P + ( ownsthis ? " - Purchased" : ( P.req_dna > changeling.absorbedcount ? " - Requires " + P.req_dna + " absorptions" : " - Cost: " + P.dna_cost ) ) + "</b>\n					</a>\n					<br><span id='item" + i + @"'></span>
				</td>
			</tr>

		";
				i++;
			}
			dat += @"
		</table>
		</span>

		<script type='text/javascript'>
			var maintable = document.getElementById(""maintable_data_archive"");
			var complete_list = maintable.innerHTML;
		</script>
	</body></html>
	";
			return dat;
		}

		// Function from file: evolution_menu.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Changeling changeling = null;
			dynamic dat = null;

			
			if ( !( Task13.User != null ) || !( Task13.User.mind != null ) || !( Task13.User.mind.changeling != null ) ) {
				return false;
			}
			changeling = Task13.User.mind.changeling;

			if ( !( GlobalVars.sting_paths != null ) ) {
				GlobalVars.sting_paths = GlobalFuncs.init_paths( typeof(Obj_Effect_ProcHolder_Changeling) );
			}
			dat = this.create_menu( changeling );
			Interface13.Browse( Task13.User, dat, "window=powers;size=600x700" );
			return false;
		}

	}

}