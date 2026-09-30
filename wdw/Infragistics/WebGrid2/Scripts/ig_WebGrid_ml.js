
/* 
Infragistics UltraWebGrid Script 
Version 2.0.5000
Copyright (c) 2003 Infragistics, Inc. All Rights Reserved.
*/

function igtbl_setActiveCell(gn,cell)
{
	var gs=igtbl_getGridById(gn);
	var ar=gs.activeRect;
	if(!ar)
		return;
	var te=gs.Element;
	if(cell)
	{
		var oldCellId=ar.getAttribute("srcElement");
		var change=true;
		var oldEditExitCancel=gs.exitEditCancel;
		igtbl_hideEdit(gn);
		if(oldCellId!=cell.id)
			if(gs.exitEditCancel || igtbl_fireEvent(gn,gs.Events.BeforeCellChange,"(\""+gn+"\",\""+cell.id+"\")")==true)
				change=false;
		if(!change)
		{
			gs.noCellChange=true;
			if(!oldCellId)
				return;
			var oldCell=igtbl_getElementById(oldCellId);
			if(oldCell.tagName=="TR")
			{
				igtbl_setActiveRow(gn,oldCell);
				return;
			}
			cell=oldCell;
		}
		gs.noCellChange=false;
		igtbl_lastActiveGrid=gn;
		ar.setAttribute("srcElement",cell.id);
		gs.ActiveCell=cell.id;
		gs.ActiveRow="";
		if(oldEditExitCancel || !gs.exitEditCancel)
		{
			if(oldCellId)
			{
				var oldRow=igtbl_getElementById(oldCellId);
				if(oldRow.tagName=="TD")
					oldRow=oldRow.parentNode;
				if(oldRow.id!=cell.parentNode.id && gs.AddNewBoxVisible)
					igtbl_setNewRowImg(gn,null);
			}
			igtbl_setSelectedRowImg(gn,cell.parentNode);
			igtbl_colButtonMouseOut(gn);
			if(gs.AddNewBoxVisible)
				igtbl_updateAddNewBox(gn);
			if(oldCellId!=cell.id)
				igtbl_fireEvent(gn,gs.Events.CellChange,"(\""+gn+"\",\""+cell.id+"\");");
		}
	}
	else
	{
		gs.ActiveCell="";
		gs.ActiveRow="";
		ar.style.display='none';
		igtbl_setSelectedRowImg(gn,null);
	}
}

function igtbl_setActiveRow(gn,row)
{
	var gs=igtbl_getGridById(gn);
	var ar=gs.activeRect;
	if(!ar)
		return;
	var te=gs.Element;
	if(row)
	{
		var oldRowId=ar.getAttribute("srcElement");
		var change=true;
		if(oldRowId!=row.id)
			if(gs.exitEditCancel || igtbl_fireEvent(gn,gs.Events.BeforeRowActivate,"(\""+gn+"\",\""+row.id+"\")")==true)
				change=false;
		if(!change)
		{
			if(!oldRowId)
				return;
			var oldRow=igtbl_getElementById(oldRowId);
			if(oldRow.tagName=="TD")
			{
				igtbl_setActiveCell(gn,oldRow);
				return;
			}
			row=oldRow;
		}
		igtbl_lastActiveGrid=gn;
		ar.setAttribute("srcElement",row.id);
		if(oldRowId)
		{
			var oldRow=igtbl_getElementById(oldRowId);
			if(oldRow.tagName=="TD")
				oldRow=oldRow.parentNode;
			if(oldRow.id!=row.id && gs.AddNewBoxVisible)
				igtbl_setNewRowImg(gn,null);
		}
		if(row.getAttribute("groupRow"))
			igtbl_setSelectedRowImg(gn,row);
		else
			igtbl_setSelectedRowImg(gn,row);
		gs.ActiveCell="";
		gs.ActiveRow=row.id;
		igtbl_hideEdit(gn);
		igtbl_colButtonMouseOut(gn);
		if(gs.AddNewBoxVisible)
			igtbl_updateAddNewBox(gn);
		if(oldRowId!=row.id)
			igtbl_fireEvent(gn,gs.Events.AfterRowActivate,"(\""+gn+"\",\""+row.id+"\");");
	}
	else
	{
		gs.ActiveCell="";
		gs.ActiveRow="";
		ar.style.display='none';
		igtbl_setSelectedRowImg(gn,null);
	}
}

function igtbl_activeRectEvent(evnt,gn)
{
	if(evnt.type=="blur")
	{
		var p=evnt.toElement;
		while(p && p.id!=gn+"_main")
			p=p.parentNode;
		if(p && p.id==gn+"_main")
			igtbl_activate(gn);
		return;
	}
	evnt.returnValue=false;
	var se=igtbl_srcElement(evnt);
	if(se.style.display=='none')
		return;
	var efp=igtbl_getElementById(se.getAttribute("srcElement"));
	if(efp)
		efp.dispatchEvent(evnt);
}
	
function igtbl_hideEdit(gn)
{
	var oGrid = igtbl_getGridById(gn);
	var oWebCombo = oGrid.webCombo
	if(oWebCombo != null) {
		var evnt=new igtbl_initEvent(sel);
		igcmbo_onblur(evnt,oWebCombo.Id);
		oWebCombo.setVisible(false);	
		oGrid.webCombo = null;
		return;
	}
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel && sel.style.display=="")
	{
		var evnt=new igtbl_initEvent(sel);
		igtbl_dropDownListFocusOut(evnt,gn);
	}
	var tb=igtbl_getElementById(gn+"_tb");
	if(tb && tb.style.display=="")
	{
		var evnt=new igtbl_initEvent(tb);
		igtbl_editBoxFocusOut(evnt,gn);
	}
	var ta=igtbl_getElementById(gn+"_ta");
	if(ta && ta.style.display=="")
	{
		var evnt=new igtbl_initEvent(ta);
		igtbl_editBoxMLFocusOut(evnt,gn);
	}
}

function igtbl_editBoxKeyDown(evnt)
{
	if(event)
		evnt=event;
	var se=igtbl_srcElement(evnt);
	var gn=se.getAttribute("gn");
	var gs=igtbl_getGridById(gn);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	se.setAttribute("noOnBlur",true);
	window.setTimeout("igtbl_cancelNoOnBlurTB('"+gn+"')",500);
	if(igtbl_fireEvent(gn,gs.Events.EditKeyDown,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")")==true)
		return true;
	if(evnt.keyCode==13 || evnt.keyCode==9)
	{
		se.removeAttribute("noOnBlur");
		igtbl_hideEdit(gn);
		if(gs.activeRect)
		{
			if(evnt.keyCode==9 && evnt.shiftKey)
				igtbl_ActivatePrevCell(gn);
			else
				igtbl_ActivateNextCell(gn);
			if(igtbl_getCellClickAction(gn,cell.parentNode.parentNode.parentNode.getAttribute("bandNo"))==1)
				igtbl_EnterEditMode(gn);
		}
		return false;
	}
	else if(evnt.keyCode==113)
		igtbl_hideEdit(gn);
	else if(evnt.keyCode==27)
	{
		if(cell.getAttribute("unmaskedValue"))
			se.value=cell.getAttribute("unmaskedValue");
		else
			se.value=se.getAttribute("oldInnerText");
		igtbl_hideEdit(gn);
	}
}

function igtbl_editBoxMLKeyDown(evnt)
{
	if(event)
		evnt=event;
	var se=igtbl_srcElement(evnt);
	var gn=se.getAttribute("gn");
	var gs=igtbl_getGridById(gn);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(igtbl_fireEvent(gn,gs.Events.EditKeyDown,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")")==true)
		return true;
	if(evnt.keyCode==9)
	{
		igtbl_hideEdit(gn);
		if(gs.activeRect)
		{
			if(evnt.shiftKey)
				igtbl_ActivatePrevCell(gn);
			else
				igtbl_ActivateNextCell(gn);
			if(igtbl_getCellClickAction(gn,cell.parentNode.parentNode.parentNode.getAttribute("bandNo"))==1)
				igtbl_EnterEditMode(gn);
		}
		return false;
	}
	else if(evnt.keyCode==113)
		igtbl_hideEdit(gn);
	else if(evnt.keyCode==27)
	{
		if(cell.getAttribute("unmaskedValue"))
			se.value=cell.getAttribute("unmaskedValue");
		else
			se.value=se.getAttribute("oldInnerText");
		igtbl_hideEdit(gn);
	}
}

function igtbl_dropDownListKeyDown(evnt)
{
	if(event)
		evnt=event;
	var se=igtbl_srcElement(evnt);
	var gn=se.getAttribute("gn");
	var gs=igtbl_getGridById(gn);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(igtbl_fireEvent(gn,gs.Events.EditKeyDown,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")")==true)
		return true;
	if(evnt.keyCode==13 || evnt.keyCode==9)
	{
		igtbl_hideEdit(gn);
		if(gs.activeRect)
		{
			if(evnt.keyCode==9 && evnt.shiftKey)
				igtbl_ActivatePrevCell(gn);
			else
				igtbl_ActivateNextCell(gn);
			if(igtbl_getCellClickAction(gn,cell.parentNode.parentNode.parentNode.getAttribute("bandNo"))==1)
				igtbl_EnterEditMode(gn);
		}
		return false;
	}
	else if(evnt.keyCode==113)
	{
		igtbl_hideEdit(gn);
		return false;
	}
	else if(evnt.keyCode==27)
	{
		for(var i=0;i<se.options.length;i++)
			if(igtbl_getInnerText(se.options[i])==se.getAttribute("oldInnerText"))
			{
				se.options[i].selected=true;
				break;
			}
		igtbl_hideEdit(gn);
	}
}

function igtbl_editBoxKeyUp(evnt)
{
	if(event)
		evnt=event;
	var se=igtbl_srcElement(evnt);
	var gn=se.getAttribute("gn");
	var gs=igtbl_getGridById(gn);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	igtbl_fireEvent(gn,gs.Events.EditKeyUp,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")");
}

function igtbl_editBoxMLKeyUp(evnt)
{
	igtbl_editBoxKeyUp(evnt);
}

function igtbl_editCell(evnt,gn,cell,keyCode)
{
	var table=cell.parentNode.parentNode.parentNode;
	var bandNo=table.getAttribute("bandNo");
	var columnNo=table.rows[0].cells[cell.cellIndex].getAttribute("columnNo");
	var gs=igtbl_getGridById(gn);
	if(gs.exitEditCancel || igtbl_getAllowUpdate(gn,bandNo,columnNo)!=1)
		return;
	var te=gs.Element;
	var column=gs.Bands[bandNo].Columns[columnNo];
	if(column.Type==3 || column.Type==7)
		return;
	if(igtbl_fireEvent(gn,gs.Events.BeforeEnterEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
		return;
	if(column.WebComboId) {
		var eCombo=igtbl_getElementById(column.WebComboId + "_Main");
		if(eCombo == null)
			return;
		var oCombo = igcmbo_getComboById(column.WebComboId);
		if(oCombo == null)
			return;
		eCombo.setAttribute("currentCell",cell.id);
		eCombo.setAttribute("oldInnerText",cell.innerText);
		eCombo.setAttribute("noOnBlur",true);
		oCombo.setDisplayValue(igtbl_getInnerText(cell));
		
		eCombo.style.position="absolute";
		if(eCombo.style.display!="")
			oCombo.setVisible(true);
		var top;
		var left;
		top = cell.offsetTop;
		var parent = cell.offsetParent;
		while(parent != null) {
			top += parent.offsetTop;
			parent = parent.offsetParent;
		}
		top -= te.parentNode.scrollTop;
		
		left = cell.offsetLeft;
		var parent = cell.offsetParent;
		while(parent != null) {
			left += parent.offsetLeft;
			parent = parent.offsetParent;
		}
		left -= te.parentNode.scrollLeft;
		
		eCombo.style.top=top;
		eCombo.style.left=left;
		eCombo.style.height=igtbl_clientHeight(cell);
		oCombo.setWidth(igtbl_clientWidth(cell));
		if(gs.activeRect && (gs.ActiveCell!="" || gs.ActiveRow!=""))
			gs.activeRect.style.display="none";

		gs.webCombo = oCombo;
		oCombo.webGrid = gs;
		gs.endCellEdit = igtbl_endCellEdit;

		window.setTimeout("igtbl_cancelNoOnBlurDD('"+gn+"')",500);
		if(fireSelChange)
			igtbl_fireEvent(gn,gs.Events.ValueListSelChange,"(\""+gn+"\",\""+gn+"_vl\",\""+sel.getAttribute("currentCell")+"\");");
	}
	else
	if(column.ValueList.length>0)
	{
		var fireSelChange=true;
		var sel=igtbl_getElementById(gn+"_vl");
		if(sel)
			igtbl_hideEdit(gn);
		var ih=igtbl_getInnerText(cell);
		cell.width=cell.offsetWidth;
		cell.height=cell.offsetHeight;
		sel=document.createElement("select");
		sel.id=gn+"_vl";
		sel.setAttribute("currentCell",cell.id);
		sel.setAttribute("gn",gn);
		sel.onkeydown=igtbl_dropDownListKeyDown;
		sel.onkeyup=igtbl_editBoxKeyUp;
		sel.setAttribute("noOnBlur",true);
		window.setTimeout("igtbl_cancelNoOnBlurTB('"+gn+"')",500);
		if(cell.childNodes && cell.childNodes.length>0 && cell.childNodes[0].tagName=="A")
		{
			sel.setAttribute("hasHref","true");
			sel.setAttribute("oldInnerText",igtbl_getInnerText(cell.childNodes[0]));
			ih=igtbl_getInnerText(cell.childNodes[0]);
		}
		else
			sel.setAttribute("oldInnerText",igtbl_getInnerText(cell));
		cell.innerHTML="";
		cell.appendChild(sel);
		if(column.ValueListPrompt!="")
		{
			var oOption = document.createElement("OPTION");
			sel.appendChild(oOption);
			oOption.value=column.ValueListPrompt;
			igtbl_setInnerText(oOption,column.ValueListPrompt);
			fireSelChange=false;
		}
		for(var i=0;i<column.ValueList.length;i++)
		{
			if(column.ValueList[i])
			{
				var oOption = document.createElement("OPTION");
				sel.appendChild(oOption);
				oOption.value=column.ValueList[i][0];
				igtbl_setInnerText(oOption,column.ValueList[i][1]);
				if(ih==column.ValueList[i][1])
				{
					oOption.selected=true;
					fireSelChange=false;
				}
			
			}
		}
		if(column.ValueListClass!="")
			sel.className=column.ValueListClass;
		sel.style.left=igtbl_getLeftPos(cell)-igtbl_adjustLeft(te);
		sel.style.top=igtbl_getTopPos(cell)+cell.offsetHeight/2-sel.offsetHeight/2-igtbl_adjustTop(te);
		sel.style.width='100%';
		if(cell.width!=cell.offsetWidth)
		{
			cell.style.width=cell.width;
			cell.style.height=cell.height;
		}
		if(fireSelChange)
			igtbl_fireEvent(gn,gs.Events.ValueListSelChange,"(\""+gn+"\",\""+gn+"_vl\",\""+sel.getAttribute("currentCell")+"\");");
		//sel.focus();
	}
	else if(column.CellMultiline==1)
	{
		var textArea=igtbl_getElementById(gn+"_ta");
		if(textArea)
			igtbl_hideEdit(gn);
		var ih=cell.innerHTML;
		cell.width=cell.offsetWidth;
		cell.height=cell.offsetHeight;
		textArea=document.createElement("textarea");
		textArea.id=gn+"_ta";
		textArea.setAttribute("currentCell",cell.id);
		textArea.setAttribute("gn",gn);
		textArea.onkeydown=igtbl_editBoxMLKeyDown;
		textArea.onkeyup=igtbl_editBoxMLKeyUp;
		if(cell.childNodes && cell.childNodes.length>0)
		{
			if(cell.childNodes[0].tagName=="A")
			{
				textArea.setAttribute("hasHref","true");
				textArea.setAttribute("oldInnerText",igtbl_getInnerText(cell.childNodes[0]));
				ih=cell.childNodes[0].innerHTML;
			}
			else if(cell.childNodes[0].tagName=="NOBR")
				ih=cell.childNodes[0].innerHTML;
		}
		else
			textArea.setAttribute("oldInnerText",igtbl_getInnerText(cell));
		cell.innerHTML="";
		cell.appendChild(textArea);
		var str=ih;
		str=str.replace(/<br>/g,"\r\n");
		textArea.value=str;
		if(igtbl_getEditCellClass(gn,bandNo)!="")
			textArea.className=igtbl_getEditCellClass(gn,bandNo);
		textArea.style.width=cell.width;
		textArea.style.height=cell.height;
		if(cell.width!=cell.offsetWidth)
		{
			cell.style.width=cell.width;
			cell.style.height=cell.height;
		}
		//textArea.focus();
		textArea.select();
	}
	else
	{
		var textBox=igtbl_getElementById(gn+"_tb");
		if(textBox)
			igtbl_hideEdit(gn);
		var ih=igtbl_getInnerText(cell);
		cell.width=cell.offsetWidth;
		cell.height=cell.offsetHeight;
		textBox=document.createElement("input");
		textBox.id=gn+"_tb";
		textBox.type="text";
		textBox.setAttribute("currentCell",cell.id);
		textBox.setAttribute("gn",gn);
		textBox.onkeydown=igtbl_editBoxKeyDown;
		textBox.onkeyup=igtbl_editBoxKeyUp;
		textBox.setAttribute("noOnBlur",true);
		if(cell.childNodes && cell.childNodes.length>0)
		{
			if(cell.childNodes[0].tagName=="A")
			{
				textBox.setAttribute("hasHref","true");
				textBox.setAttribute("oldInnerText",igtbl_getInnerText(cell.childNodes[0]));
				ih=igtbl_getInnerText(cell.childNodes[0]);
			}
			else if(cell.childNodes[0].tagName=="NOBR")
				ih=cell.childNodes[0].innerHTML;
		}
		else
			textBox.setAttribute("oldInnerText",igtbl_getInnerText(cell));
		cell.innerHTML="";
		cell.appendChild(textBox);
		if(column.FieldLength>0)
			textBox.maxLength=column.FieldLength;
		else
			textBox.maxLength=2147483647;
		if(cell.getAttribute("unmaskedValue"))
			textBox.value=cell.getAttribute("unmaskedValue");
		else
			textBox.value=ih;
		if(igtbl_getEditCellClass(gn,bandNo)!="")
			textBox.className=igtbl_getEditCellClass(gn,bandNo);
		textBox.style.width=cell.width;
		textBox.style.height=cell.height;
		if(cell.width!=cell.offsetWidth)
		{
			cell.style.width=cell.width;
			cell.style.height=cell.height;
		}
		//textBox.focus();
		textBox.select();
		window.setTimeout("igtbl_cancelNoOnBlurTB('"+gn+"')",500);
	}
	igtbl_fireEvent(gn,gs.Events.AfterEnterEditMode,"(\""+gn+"\",\""+cell.id+"\");");
}

function igtbl_endCellEdit()
{
	if(this.webCombo != null) {
		var eCombo = this.webCombo.Element
		var cell=igtbl_getElementById(eCombo.getAttribute("currentCell"));
		if(!cell)
			return;
		var gn = this.Id;
		var gs=igtbl_getGridById(gn);
		var oldText=igtbl_getInnerText(cell);

		var hasHref=false;
		if(cell.childNodes && cell.childNodes.length>0 && cell.childNodes[0].tagName=="A")
		{
			hasHref=true;
			oldText=igtbl_getInnerText(cell.childNodes[0]);
		}
		if(!cell.getAttribute("oldValue"))
			cell.setAttribute("oldValue",oldText);
		var changed=false;
		var column=igtbl_getColumnById(cell.id);
		var displayValue=this.webCombo.getDisplayValue();
		this.webCombo.setDropDown(false);
		if(hasHref)
			changed=(igtbl_getInnerText(cell.childNodes[0])!=displayValue);
		else
			changed=(igtbl_getInnerText(cell)!=displayValue);
		if(changed && !gs.insideBeforeUpdate)
		{
			gs.insideBeforeUpdate=true;
			var value=igtbl_fireEvent(gn,gs.Events.BeforeCellUpdate,"(\""+gn+"\",\""+cell.id+"\",\""+value+"\")");
			gs.insideBeforeUpdate=false;
			if(value==true)
				changed=false;
		}
		if(changed)
		{
			if(!displayValue)
				displayValue=this.webCombo.getDisplayValue();
			if(displayValue=="")
				displayValue=" ";
			if(hasHref)
			{
				igtbl_setInnerText(cell.childNodes[0],displayValue);
				cell.childNodes[0].href=(value.indexOf('@')>=0?"mailto:":"")+cell.childNodes[0].innerText;
			}
			else
				igtbl_setInnerText(cell.childNodes[0],displayValue);
			if(displayValue==" ")
				displayValue="";
			if(displayValue!=eCombo.getAttribute("oldInnerText"))
				gs.ChangedCells[cell.id]=this.webCombo.getDataValue();
		}
		if(igtbl_fireEvent(gn,gs.Events.BeforeExitEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
		{
			if(!gs.exitEditCancel && !gs.insideSetActive)
			{
				gs.insideSetActive=true;
				igtbl_setActiveCell(gn,igtbl_getElementById(eCombo.getAttribute("currentCell")));
				gs.insideSetActive=false;
			}
			gs.exitEditCancel=true;
			return;
		}
		this.webCombo.setVisible(false);
		gs.exitEditCancel=false;
		eCombo.removeAttribute("currentCell");
		eCombo.removeAttribute("oldInnerText");
		if(gs.ActiveCell!="")
			igtbl_setActiveCell(gn,igtbl_getElementById(gs.ActiveCell));
		else if(gs.ActiveRow!="")
			igtbl_setActiveRow(gn,igtbl_getElementById(gs.ActiveRow));

		igtbl_updatePostField(gn);
		igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
		if(changed)
		{
			igtbl_fireEvent(gn,gs.Events.AfterCellUpdate,"(\""+gn+"\",\""+cell.id+"\");");
			if(gs.NeedPostBack)
			{
				gs.GridIsLoaded=false;
				igtbl_doPostBack(gn);
			}
		}
		this.webCombo = null;
		return;		
	}
}

function igtbl_dropDownListFocusOut(evnt,gn)
{
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(!cell || se.getAttribute("noOnBlur"))
		return;
	var gs=igtbl_getGridById(gn);
	var oldText=se.getAttribute("oldInnerText");
	if(!cell.getAttribute("oldValue"))
		cell.setAttribute("oldValue",oldText);
	var column=igtbl_getColumnById(cell.id);
	var value=igtbl_getInnerText(se.options[se.selectedIndex]);
	var changed=(oldText!=value);
	if(changed && value!=column.ValueListPrompt)
	{
		value=igtbl_fireEvent(gn,gs.Events.BeforeCellUpdate,"(\""+gn+"\",\""+cell.id+"\",\""+value+"\")");
		if(value==true)
			changed=false;
	}
	if(igtbl_fireEvent(gn,gs.Events.BeforeExitEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
	{
		if(!gs.exitEditCancel && !gs.insideSetActive)
		{
			gs.insideSetActive=true;
			igtbl_setActiveCell(gn,igtbl_getElementById(se.getAttribute("currentCell")));
			gs.insideSetActive=false;
		}
		gs.exitEditCancel=true;
		return;
	}
	gs.exitEditCancel=false;
	if(changed)
	{
		if(value==false || value==undefined)
			value=igtbl_getInnerText(se.options[se.selectedIndex]);
		if(value=="")
			value=" ";
		if(column.ValueListPrompt!="" && se.selectedIndex==0)
			value=se.getAttribute("oldInnerText");
		if(se.getAttribute("hasHref"))
		{
			cell.innerHTML="";
			var l=document.createElement("A");
			l.href=(value.indexOf('@')>=0?"mailto:":"")+value;
			igtbl_setInnerText(l,value);
			cell.appendChild(l);
		}
		else if(cell.childNodes.length>0 && cell.childNodes[0].tagName=="NOBR")
			igtbl_setInnerText(cell.childNodes[0],value);
		else
			igtbl_setInnerText(cell,value);
		if(value==" ")
			value="";
		gs.ChangedCells[cell.id]=value;
	}
	else
	{
		if(se.getAttribute("hasHref"))
		{
			cell.innerHTML="";
			var l=document.createElement("A");
			l.href=(oldText.indexOf('@')>=0?"mailto:":"")+oldText;
			igtbl_setInnerText(l,oldText);
			cell.appendChild(l);
		}
		else
			igtbl_setInnerText(cell,oldText);
	}
	if(gs.ActiveCell!="")
		igtbl_setActiveCell(gn,igtbl_getElementById(gs.ActiveCell));
	else if(gs.ActiveRow!="")
		igtbl_setActiveRow(gn,igtbl_getElementById(gs.ActiveRow));
	igtbl_updatePostField(gn);
	igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
	if(changed)
	{
		igtbl_fireEvent(gn,gs.Events.AfterCellUpdate,"(\""+gn+"\",\""+cell.id+"\");");
		if(gs.NeedPostBack)
			igtbl_doPostBack(gn);
	}
}

function igtbl_editBoxFocusOut(evnt,gn)
{
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(!cell || se.getAttribute("noOnBlur"))
		return;
	var gs=igtbl_getGridById(gn);
	var oldText=se.getAttribute("oldInnerText");
	if(!cell.getAttribute("oldValue"))
		cell.setAttribute("oldValue",oldText);
	var value=se.value;
	var column=gs.Bands[cell.parentNode.parentNode.parentNode.getAttribute("bandNo")].Columns[igtbl_getColumnNo(gn,cell)];
	if(column.MaskDisplay!="")
	{
		value=igtbl_Mask(gn,value,column.DataType,column.MaskDisplay);
		if(value=="")
			value=oldText;
	}
	if(column.Case==1)
		value=value.toLowerCase();
	else if(column.Case==2)
		value=value.toUpperCase();
	var changed=(oldText!=value);
	if(changed)
	{
		value=igtbl_fireEvent(gn,gs.Events.BeforeCellUpdate,"(\""+gn+"\",\""+cell.id+"\",\""+value+"\")");
		if(value==true)
			changed=false;
	}
	if(igtbl_fireEvent(gn,gs.Events.BeforeExitEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
	{
		if(!gs.exitEditCancel && !gs.insideSetActive)
		{
			gs.insideSetActive=true;
			igtbl_setActiveCell(gn,igtbl_getElementById(se.getAttribute("currentCell")));
			gs.insideSetActive=false;
		}
		gs.exitEditCancel=true;
		return;
	}
	gs.exitEditCancel=false;
	if(changed)
	{
		var iValue=se.value;
		if(value==false || value==undefined)
		{
			value=iValue;
			if(column.MaskDisplay!="")
			{
				value=igtbl_Mask(gn,value,column.DataType,column.MaskDisplay);
				if(value=="")
					value=oldText;
			}
			if(column.Case==1)
				value=value.toLowerCase();
			else if(column.Case==2)
				value=value.toUpperCase();
		}
		if(value=="")
			value=" ";
		if(se.getAttribute("hasHref"))
		{
			cell.innerHTML="";
			var l=document.createElement("A");
			l.href=(value.indexOf('@')>=0?"mailto:":"")+value;
			igtbl_setInnerText(l,value);
			cell.appendChild(l);
		}
		else if(cell.childNodes.length>0 && cell.childNodes[0].tagName=="NOBR")
			igtbl_setInnerText(cell.childNodes[0],value);
		else
			igtbl_setInnerText(cell,value);
		if(value==" ")
			value="";
		if(column.MaskDisplay!="")
		{
			value=igtbl_clarifyInput(gn,iValue.toString(),column.DataType);
			cell.setAttribute("unmaskedValue",value);
		}
		else if(column.FieldLength!=0 || column.Case!=0)
		{
			value=se.value;
			cell.setAttribute("unmaskedValue",value);
		}
		gs.ChangedCells[cell.id]=value;
	}
	else
	{
		if(se.getAttribute("hasHref"))
		{
			cell.innerHTML="";
			var l=document.createElement("A");
			l.href=(oldText.indexOf('@')>=0?"mailto:":"")+oldText;
			igtbl_setInnerText(l,oldText);
			cell.appendChild(l);
		}
		else
			igtbl_setInnerText(cell,oldText);
	}
	if(gs.ActiveCell!="")
		igtbl_setActiveCell(gn,igtbl_getElementById(gs.ActiveCell));
	else if(gs.ActiveRow!="")
		igtbl_setActiveRow(gn,igtbl_getElementById(gs.ActiveRow));
	igtbl_updatePostField(gn);
	igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
	if(changed)
	{
		igtbl_fireEvent(gn,gs.Events.AfterCellUpdate,"(\""+gn+"\",\""+cell.id+"\");");
		if(gs.NeedPostBack)
			igtbl_doPostBack(gn);
	}
}

function igtbl_editBoxMLFocusOut(evnt,gn)
{
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(!cell || se.getAttribute("noOnBlur"))
		return;
	var gs=igtbl_getGridById(gn);
	var oldText=cell.innerHTML.replace(/<BR>/g,"\r\n");
	if(!cell.getAttribute("oldValue"))
		cell.setAttribute("oldValue",oldText);
	var value=se.value;
	var column=gs.Bands[cell.parentNode.parentNode.parentNode.getAttribute("bandNo")].Columns[igtbl_getColumnNo(gn,cell)];
	if(column.MaskDisplay!="")
	{
		value=igtbl_Mask(gn,value,column.DataType,column.MaskDisplay);
		if(value=="")
			value=oldText;
	}
	if(column.FieldLength>0)
		value=value.substr(0,column.FieldLength);
	if(column.Case==1)
		value=value.toLowerCase();
	else if(column.Case==2)
		value=value.toUpperCase();
	var changed=(oldText!=value);
	if(changed)
	{
		value=igtbl_fireEvent(gn,gs.Events.BeforeCellUpdate,"(\""+gn+"\",\""+cell.id+"\",\""+value+"\")");
		if(value==true)
			changed=false;
	}
	if(igtbl_fireEvent(gn,gs.Events.BeforeExitEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
	{
		if(!gs.exitEditCancel && !gs.insideSetActive)
		{
			gs.insideSetActive=true;
			igtbl_setActiveCell(gn,igtbl_getElementById(se.getAttribute("currentCell")));
			gs.insideSetActive=false;
		}
		gs.exitEditCancel=true;
		return;
	}
	gs.exitEditCancel=false;
	if(changed)
	{
		var iValue=se.value;
		if(value==false || value==undefined)
		{
			value=iValue;
			if(column.MaskDisplay!="")
			{
				value=igtbl_Mask(gn,value,column.DataType,column.MaskDisplay);
				if(value=="")
					value=oldText;
			}
			if(column.FieldLength>0)
				value=value.substr(0,column.FieldLength);
			if(column.Case==1)
				value=value.toLowerCase();
			else if(column.Case==2)
				value=value.toUpperCase();
		}
		if(value=="")
			value=" ";
		if(se.getAttribute("hasHref"))
		{
			cell.innerHTML="";
			var l=document.createElement("A");
			l.href=(value.indexOf('@')>=0?"mailto:":"")+value;
			l.innerHTML=value.replace(/\r\n/g,"<BR>");
			cell.appendChild(l);
		}
		else if(cell.childNodes.length>0 && cell.childNodes[0].tagName=="NOBR")
			cell.childNodes[0].innerHTML=value.replace(/\r\n/g,"<BR>");
		else
			cell.innerHTML=value.replace(/\r\n/g,"<BR>");
		if(value==" ")
			value="";
		if(column.MaskDisplay!="")
		{
			value=igtbl_clarifyInput(gn,value.toString(),column.DataType);
			cell.setAttribute("unmaskedValue",value);
		}
		else if(column.FieldLength!=0 || column.Case!=0)
		{
			value=se.value;
			cell.setAttribute("unmaskedValue",value);
		}
		gs.ChangedCells[cell.id]=value;
	}
	else
	{
		if(se.getAttribute("hasHref"))
		{
			cell.innerHTML="";
			var l=document.createElement("A");
			l.href=(oldText.indexOf('@')>=0?"mailto:":"")+oldText;
			l.innerHTML=oldText.replace(/\r\n/g,"<BR>");
			cell.appendChild(l);
		}
		else
			cell.innerHTML=oldText.replace(/\r\n/g,"<BR>");
	}
	if(gs.ActiveCell!="")
		igtbl_setActiveCell(gn,igtbl_getElementById(gs.ActiveCell));
	else if(gs.ActiveRow!="")
		igtbl_setActiveRow(gn,igtbl_getElementById(gs.ActiveRow));
	igtbl_updatePostField(gn);
	igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
	if(changed)
	{
		igtbl_fireEvent(gn,gs.Events.AfterCellUpdate,"(\""+gn+"\",\""+cell.id+"\");");
		if(gs.NeedPostBack)
			igtbl_doPostBack(gn);
	}
}

function igtbl_getOffsetX(evnt,e)
{
	return evnt.clientX-igtbl_getLeftPos(e);
}

function igtbl_getOffsetY(evnt,e)
{
	return evnt.clientY-igtbl_getTopPos(e);
}

function igtbl_onResize(gn)
{
}

function igtbl_isDisabled(elem)
{
	return elem.getAttribute("disabled") && elem.getAttribute("disabled").toString()=="true";
}

function igtbl_setDisabled(elem,b)
{
	elem.setAttribute("disabled",b);
}
