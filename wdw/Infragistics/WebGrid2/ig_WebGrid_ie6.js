
/* 
Infragistics UltraWebGrid Script 
Version 2.1.20033.4
Copyright (c) 2001-2003 Infragistics, Inc. All Rights Reserved.
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
		var oldRowObj=igtbl_getRowById(oldCellId);
		var cellObj=igtbl_getCellById(cell.id);
		var change=true;
		var oldEditExitCancel=gs.exitEditCancel;
		igtbl_hideEdit(gn);
		if(oldCellId!=cell.id)
		{
			if(gs.exitEditCancel || igtbl_fireEvent(gn,gs.Events.BeforeCellChange,"(\""+gn+"\",\""+cell.id+"\")")==true)
				change=false;
			if(cellObj.Row!=oldRowObj)
				if(gs.exitEditCancel || igtbl_fireEvent(gn,gs.Events.BeforeRowActivate,"(\""+gn+"\",\""+cellObj.Row.Element.id+"\")")==true)
					change=false;
		}
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
		ar.setAttribute("srcElement",cell.id);
		gs.ActiveCell=cell.id;
		gs.ActiveRow="";
		if(igtbl_isVisible(cell) && !gs.exitEditCancel && !gs.insideSetActive)
		{
			ar.style.display='';
			ar.style.left=igtbl_getLeftPos(cell)-igtbl_getLeftPos(te);
			var t=igtbl_getTopPos(cell)-igtbl_getTopPos(te);
			ar.style.top=t;
			ar.style.width=cell.clientWidth;
			ar.style.height=cell.clientHeight;
		}
		else
			ar.style.display='none';
		if(oldEditExitCancel || !gs.exitEditCancel)
		{
			if(oldCellId)
			{
				var oldRow=igtbl_getElementById(oldCellId);
				if(oldRow && oldRow.tagName=="TD")
					oldRow=oldRow.parentNode;
				if(oldRow && oldRow.id!=cell.parentNode.id && gs.AddNewBoxVisible)
					igtbl_setNewRowImg(gn,null);
			}
			igtbl_setSelectedRowImg(gn,cell.parentElement);
			igtbl_colButtonMouseOut(gn);
			if(gs.AddNewBoxVisible)
				igtbl_updateAddNewBox(gn);
			if(oldCellId!=cell.id)
			{
				igtbl_fireEvent(gn,gs.Events.CellChange,"(\""+gn+"\",\""+cell.id+"\");");
				if(cellObj.Row!=oldRowObj)
					igtbl_fireEvent(gn,gs.Events.AfterRowActivate,"(\""+gn+"\",\""+cellObj.Row.Element.id+"\");");
			}
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
		var oldRow=igtbl_getElementById(oldRowId);
		if(oldRow && oldRow.tagName=="TD")
			oldRowId=oldRow.parentNode.id;
		var change=true;
		if(oldRowId!=row.id)
			if(gs.exitEditCancel || igtbl_fireEvent(gn,gs.Events.BeforeRowActivate,"(\""+gn+"\",\""+row.id+"\")")==true)
				change=false;
		if(!change)
		{
			if(!ar.getAttribute("srcElement"))
				return;
			if(oldRow.tagName=="TD")
			{
				igtbl_setActiveCell(gn,oldRow);
				return;
			}
			row=oldRow;
		}
		ar.setAttribute("srcElement",row.id);
		var isRowVis=igtbl_isVisible(row);
		if(isRowVis)
			ar.style.display='';
		else
			ar.style.display='none';
		if(oldRowId)
		{
			var oldRow=igtbl_getElementById(oldRowId);
			if(oldRow && oldRow.tagName=="TD")
				oldRow=oldRow.parentNode;
			if(oldRow && oldRow.id!=row.id && gs.AddNewBoxVisible)
				igtbl_setNewRowImg(gn,null);
		}
		gs.ActiveCell="";
		gs.ActiveRow=row.id;
		if(row.getAttribute("groupRow"))
		{
			if(isRowVis && !gs.exitEditCancel && !gs.insideSetActive)
			{
				ar.style.left=igtbl_getLeftPos(row)-igtbl_getLeftPos(te);
				var t=igtbl_getTopPos(row)-igtbl_getTopPos(te);
				ar.style.top=t;
				ar.style.width=row.clientWidth;
				ar.style.height=row.clientHeight;
			}
			igtbl_setSelectedRowImg(gn,row);
		}
		else
		{
			var lc=row.cells[row.cells.length-1];
			while(lc && lc.style.display!="") lc=lc.previousSibling;
			if(lc && isRowVis && !gs.exitEditCancel && !gs.insideSetActive)
			{
				var fac=igtbl_getElemVis(row.cells,igtbl_getBandFAC(gn,row));
				ar.style.left=igtbl_getLeftPos(fac)-igtbl_getLeftPos(te);
				var t=igtbl_getTopPos(row)-igtbl_getTopPos(te);
				ar.style.top=t;
				var lc=row.cells[row.cells.length-1];
				while(lc.style.display!="") lc=lc.previousSibling;
				var w=lc.clientWidth;
				ar.style.width=igtbl_getLeftPos(lc)+w-igtbl_getLeftPos(igtbl_getElemVis(row.childNodes,igtbl_getBandFAC(gn,row)));
				ar.style.height=row.clientHeight;
			}
			igtbl_setSelectedRowImg(gn,row);
		}
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
	se.style.display='none';
	var efp=document.elementFromPoint(evnt.clientX,evnt.clientY);
	se.style.display='';
	if(efp)
	{
		efp.fireEvent("on"+evnt.type,evnt);
		evnt.cancelBubble=true;
		evnt.returnValue=false;
	}
}

function igtbl_getOffsetX(evnt,e)
{
	return evnt.offsetX;
}

function igtbl_getOffsetY(evnt,e)
{
	return evnt.offsetY;
}

function igtbl_activate(gn)
{
	var g=igtbl_getGridById(gn);
	if(typeof(document.activeElement)=="unknown" || document.activeElement==g.Element.parentNode)
		return;
	var sel=igtbl_getElementById(gn+"_vl");
	var tb=igtbl_getElementById(gn+"_tb");
	var ta=igtbl_getElementById(gn+"_ta");
	if(sel && sel.style.display=="")
		sel.setActive();
	else if(tb && tb.style.display=="")
		tb.setActive();
	else if(ta && ta.style.display=="")
		ta.setActive();
	else if(g.Element.offsetWidth != 0 && g.Element.offsetHeight != 0)	
		try{g.Element.setActive();}catch(e){;}
}

function igtbl_hideEdit(gn)
{
	var g = igtbl_getGridById(gn);
	var oEditor = g.editorControl;
	if(oEditor)
	{
		oEditor.Element.removeAttribute("noOnBlur");
		if(igtbl_endCustomEdit.apply)
			igtbl_endCustomEdit.apply(oEditor);
		else if(oEditor.endEditCell)
			oEditor.endEditCell();
		else
			oEditor.setVisible(false);
		g.editorControl = null;
		return;
	}
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel && sel.style.display=="")
	{
		sel.removeAttribute("noOnBlur");
		sel.fireEvent("onblur");
	}
	var tb=igtbl_getElementById(gn+"_tb");
	if(tb && tb.style.display=="")
	{
		tb.removeAttribute("noOnBlur");
		tb.fireEvent("onblur");
	}
	var ta=igtbl_getElementById(gn+"_ta");
	if(ta && ta.style.display=="")
	{
		ta.removeAttribute("noOnBlur");
		ta.fireEvent("onblur");
	}
}

function igtbl_editBoxKeyDown(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	se.setAttribute("noOnBlur",true);
	window.setTimeout("igtbl_cancelNoOnBlurTB('"+gn+"')",100);
	if(igtbl_fireEvent(gn,gs.Events.EditKeyDown,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")")==true)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return true;
	}
	if(evnt.keyCode==13 || evnt.keyCode==9)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		se.removeAttribute("noOnBlur");
		var res=null;
		if(gs.activeRect)
		{
			if(evnt.keyCode==9 && evnt.shiftKey)
				res=igtbl_ActivatePrevCell(gn);
			else
				res=igtbl_ActivateNextCell(gn);
			if(res && igtbl_getCellClickAction(gn,cell.parentNode.parentNode.parentNode.getAttribute("bandNo"))==1)
				igtbl_EnterEditMode(gn);
			else
				igtbl_EndEditMode(gn);
		}
		else
			igtbl_hideEdit(gn);
		return true;
	}
	else if(evnt.keyCode==113)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		igtbl_hideEdit(gn);
		igtbl_activate(gn);
		return false;
	}
	else if(evnt.keyCode==27)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		if(cell.getAttribute("unmaskedValue"))
			se.value=cell.getAttribute("unmaskedValue");
		else
			se.value=se.getAttribute("oldInnerText");
		igtbl_hideEdit(gn);
		igtbl_activate(gn);
		return false;
	}
}

function igtbl_editBoxMLKeyDown(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(igtbl_fireEvent(gn,gs.Events.EditKeyDown,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")")==true)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return true;
	}
	if(evnt.keyCode==9)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		se.removeAttribute("noOnBlur");
		var res=null;
		if(gs.activeRect)
		{
			if(evnt.shiftKey)
				res=igtbl_ActivatePrevCell(gn);
			else
				res=igtbl_ActivateNextCell(gn);
			if(res && igtbl_getCellClickAction(gn,cell.parentNode.parentNode.parentNode.getAttribute("bandNo"))==1)
				igtbl_EnterEditMode(gn);
			else
				igtbl_EndEditMode(gn);
		}
		else
			igtbl_hideEdit(gn);
		return false;
	}
	else if(evnt.keyCode==113)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		igtbl_hideEdit(gn);
		igtbl_activate(gn);
		return false;
	}
	else if(evnt.keyCode==27)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		if(cell.getAttribute("unmaskedValue"))
			se.value=cell.getAttribute("unmaskedValue");
		else
			se.value=se.getAttribute("oldInnerText");
		igtbl_hideEdit(gn);
		igtbl_activate(gn);
		return false;
	}
}

function igtbl_dropDownListKeyDown(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(igtbl_fireEvent(gn,gs.Events.EditKeyDown,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")")==true)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return true;
	}
	if(evnt.keyCode==9)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		se.removeAttribute("noOnBlur");
		var res=null;
		if(gs.activeRect)
		{
			if(evnt.keyCode==9 && evnt.shiftKey)
				res=igtbl_ActivatePrevCell(gn);
			else
				res=igtbl_ActivateNextCell(gn);
			if(!res)
				igtbl_dropDownListFocusOut(evnt,gn);
			if(res && igtbl_getCellClickAction(gn,cell.parentNode.parentNode.parentNode.getAttribute("bandNo"))==1)
				igtbl_EnterEditMode(gn);
		}
		else
			igtbl_hideEdit(gn);
		return false;
	}
	else if(evnt.keyCode==113)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		igtbl_hideEdit(gn);
		igtbl_activate(gn);
		return false;
	}
	else if(evnt.keyCode==27)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		for(var i=0;i<se.options.length;i++)
			if(se.options[i].innerText==cell.innerText)
			{
				try{se.options[i].selected=true;}catch(e){}
				break;
			}
		igtbl_hideEdit(gn);
		igtbl_activate(gn);
		return false;
	}
}

function igtbl_editBoxKeyUp(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	igtbl_fireEvent(gn,gs.Events.EditKeyUp,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")");
}

function igtbl_editBoxMLKeyUp(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	var se=igtbl_srcElement(evnt);
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	igtbl_fireEvent(gn,gs.Events.EditKeyUp,"(\""+gn+"\",\""+cell.id+"\","+evnt.keyCode+")");
}

function igtbl_editCell(evnt,gn,cell,keyCode)
{
	var table=cell.parentNode.parentNode.parentNode;
	var cellObj=igtbl_getCellById(cell.id);
	if(!cellObj)
		return;
	var bandNo=cellObj.Column.Band.Index;
	var columnNo=igtbl_getElemVis(table.rows[0].cells,cell.cellIndex).getAttribute("columnNo");
	var gs=igtbl_getGridById(gn);
	if(gs.exitEditCancel || !cellObj.isEditable())
		return;
	var te=gs.Element;
	var column=cellObj.Column;
	if(column.Type==3 || column.Type==7)
		return;
	if(igtbl_fireEvent(gn,gs.Events.BeforeEnterEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
		return;
	if(column.EditorControlID)
	{
		if(igtbl_getElementById(column.EditorControlID)==null)
			return;
		var oEditor=igtbl_getElementById(column.EditorControlID).Object;
		if(typeof(oEditor)=="undefined")
			return;
		var eEditor=oEditor.Element;
		eEditor.setAttribute("editorControl",true);
		eEditor.setAttribute("currentCell",cell.id);
		eEditor.setAttribute("oldInnerText",cell.innerText);
		eEditor.setAttribute("noOnBlur",true);
		oEditor.setValue(cellObj.getValue());
		cellObj.scrollToView();
		var mainGrid=igtbl_getElementById(gn+"_main");
		var left;
		var top = cell.offsetTop;
		var parent = cell.offsetParent;
		while(!(parent==null || parent!=mainGrid && parent.tagName=="TABLE" && (parent.style.position=="absolute" || parent.style.position=="relative"))) {
			top += parent.offsetTop;
			parent = parent.offsetParent;
		}
		top -= te.offsetParent.scrollTop;
		
		left = cell.offsetLeft;
		var parent = cell.offsetParent;
		while(!(parent==null || parent!=mainGrid && parent.tagName=="TABLE" && (parent.style.position=="absolute" || parent.style.position=="relative"))) {
			left += parent.offsetLeft;
			parent = parent.offsetParent;
		}
		left -= te.offsetParent.scrollLeft;
		
		eEditor.style.position="absolute";
		oEditor.setVisible(true,left,top,igtbl_clientWidth(cell),igtbl_clientHeight(cell));
		
		if(gs.activeRect && (gs.ActiveCell!="" || gs.ActiveRow!=""))
			gs.activeRect.style.display="none";

		eEditor.focus();
		gs.editorControl = oEditor;
		oEditor.webGrid = gs;
		oEditor.endEditCell=igtbl_endCustomEdit;
		
		/* remove next line after 2.1 release */
		gs.webCombo = oEditor;

		window.setTimeout("igtbl_cancelNoOnBlurDD('"+gn+"')",100);
	}
	else if(column.ValueList.length>0)
	{
		var sel=igtbl_getElementById(gn+"_vl");
		if(sel)
		{
			var fireSelChange=true;
			while(sel.childNodes.length>0)
				sel.removeChild(sel.childNodes[0]);
			if(column.ValueListPrompt!="")
			{
				var oOption = document.createElement("OPTION");
				sel.appendChild(oOption);
				oOption.value=column.ValueListPrompt;
				oOption.innerText=column.ValueListPrompt;
				fireSelChange=false;
			}
			sel.inited=false;
			for(var i=0;i<column.ValueList.length;i++)
			{
				if(column.ValueList[i])
				{
					var oOption = document.createElement("OPTION");
					sel.appendChild(oOption);
					oOption.value=column.ValueList[i][0];
					oOption.innerText=column.ValueList[i][1];
					if(!sel.inited)
					{
						if(cell.getAttribute("igDataValue"))
						{
							if(cell.getAttribute("igDataValue")==igtbl_trim(column.ValueList[i][0]))
							{
								try{oOption.selected=true;}catch(e){}
								fireSelChange=false;
								sel.inited=true;
							}
						}
						else if(igtbl_trim(cell.innerText)==igtbl_trim(column.ValueList[i][1]))
						{
							try{oOption.selected=true;}catch(e){}
							fireSelChange=false;
							sel.inited=true;
						}
					}
				}
			}
			sel.setAttribute("currentCell",cell.id);
			sel.setAttribute("oldInnerText",cell.innerText);
			sel.className=column.ValueListClass;
			sel.setAttribute("noOnBlur",true);
			sel.style.display="";
			var selHeight=sel.offsetHeight;
			te.runtimeStyle.cssText="";
			gs.Element.setAttribute("noOnResize",true);
			sel.style.left=igtbl_getLeftPos(cell)-igtbl_adjustLeft(te);
			var t;
			var so=igtbl_getStyleObj(sel.className);
			if(so && so.verticalAlign=="top")
				t=igtbl_getTopPos(cell)-igtbl_adjustTop(te);
			else if(so && so.verticalAlign=="bottom")
				t=igtbl_getTopPos(cell)+cell.offsetHeight-selHeight-igtbl_adjustTop(te);
			else
				t=igtbl_getTopPos(cell)+cell.offsetHeight/2-selHeight/2-igtbl_adjustTop(te);
			gs.Element.removeAttribute("noOnResize");
			sel.style.top=t;
			sel.style.width=igtbl_clientWidth(cell);
			if(gs.activeRect && (gs.ActiveCell!="" || gs.ActiveRow!=""))
				gs.activeRect.style.display="none";
			if(sel.style.display!="")
			{
				sel.style.display="";
				sel.setAttribute("currentCell",cell.id);
				sel.setAttribute("oldInnerText",cell.innerText);
			}
			sel.focus();
			if(evnt && keyCode && keyCode!=113)
			{
				evnt.keyCode=keyCode;
				sel.fireEvent("onkeydown",evnt);
			}
			window.setTimeout("igtbl_cancelNoOnBlurTB('"+gn+"')",100);
			if(fireSelChange)
				igtbl_fireEvent(gn,gs.Events.ValueListSelChange,"(\""+gn+"\",\""+gn+"_vl\",\""+sel.getAttribute("currentCell")+"\");");
		}
	}
	else if(column.CellMultiline==1)
	{
		var textArea=igtbl_getElementById(gn+"_ta");
		if(textArea)
		{
			textArea.setAttribute("currentCell",cell.id);
			var str=cell.innerText;
			textArea.setAttribute("oldInnerText",str);
			igtbl_setInnerText(textArea,str);
			textArea.setAttribute("noOnBlur",true);
			textArea.style.display="";
			textArea.style.left=igtbl_getLeftPos(cell)-igtbl_adjustLeft(te);
			var t=igtbl_getTopPos(cell)-igtbl_adjustTop(te);
			textArea.style.top=t;
			textArea.style.width=igtbl_clientWidth(cell);
			textArea.style.height=igtbl_clientHeight(cell);
			if(igtbl_getEditCellClass(gn,bandNo)!="")
			{
				textArea.className=igtbl_getEditCellClass(gn,bandNo);
				textArea.style.whiteSpace="normal";
			}
			textArea.style.overflow="auto";
			if(gs.activeRect && (gs.ActiveCell!="" || gs.ActiveRow!=""))
				gs.activeRect.style.display="none";
			if(textArea.style.display!="")
			{
				textArea.style.display="";
				textArea.setAttribute("currentCell",cell.id);
				textArea.setAttribute("oldInnerText",cell.innerText);
			}
			textArea.focus();
			textArea.select();
			if(evnt && keyCode && keyCode!=113)
			{
				evnt.keyCode=keyCode;
				textArea.fireEvent("onkeydown",evnt);
			}
			window.setTimeout("igtbl_cancelNoOnBlurTA('"+gn+"')",100);
		}
	}
	else
	{
		var textBox=igtbl_getElementById(gn+"_tb");
		if(textBox)
		{
			if(column.FieldLength>0)
				textBox.maxLength=column.FieldLength;
			else
				textBox.maxLength=2147483647;
			textBox.setAttribute("currentCell",cell.id);
			textBox.style.display="";
			textBox.style.left=igtbl_getLeftPos(cell)-igtbl_adjustLeft(te);
			var t=igtbl_getTopPos(cell)-igtbl_adjustTop(te);
			textBox.style.top=t;
			textBox.style.width=igtbl_clientWidth(cell);
			textBox.style.height=igtbl_clientHeight(cell);
			textBox.className=igtbl_getEditCellClass(gn,bandNo);
			textBox.setAttribute("oldInnerText",cell.innerText);
			if(cell.getAttribute("unmaskedValue"))
				textBox.value=cell.getAttribute("unmaskedValue");
			else
				textBox.value=cell.innerText;
			textBox.setAttribute("noOnBlur",true);
			if(column.Validators.length>0 && typeof(Page_Validators)!="undefined")
			{
				for(var i=0;i<column.Validators.length;i++)
				{
					var val=igtbl_getElementById(column.Validators[i]);
					val.setAttribute("controltovalidate",textBox.id);
					ValidatorHookupControlID(textBox.id, val);
					val.style.left=textBox.offsetLeft+igtbl_adjustLeft(te);
					val.style.top=textBox.offsetTop+textBox.offsetHeight+igtbl_adjustTop(te);
				}
			}
			if(typeof(Page_Validators)!="undefined")
			{
				for(var i=0;i<Page_Validators.length;i++)
					if(Page_Validators[i].controltovalidate==gs.Id+"_tb")
					{
						for(var j=0;j<column.Validators.length;j++)
							if(Page_Validators[i].id==column.Validators[j])
								break;
						Page_Validators[i].enabled=(column.Validators.length>0 && j<column.Validators.length);
						Page_Validators[i].isvalid=true;
					}
			}
			if(gs.activeRect && (gs.ActiveCell!="" || gs.ActiveRow!=""))
				gs.activeRect.style.display="none";
			if(textBox.style.display!="")
			{
				textBox.style.display="";
				textBox.setAttribute("currentCell",cell.id);
				textBox.setAttribute("oldInnerText",cell.innerText);
			}
			textBox.focus();
			textBox.select();
			if(evnt && keyCode && keyCode!=113)
			{
				evnt.keyCode=keyCode;
				textBox.fireEvent("onkeydown",evnt);
			}
			window.setTimeout("igtbl_cancelNoOnBlurTB('"+gn+"')",100);
		}
	}
	igtbl_fireEvent(gn,gs.Events.AfterEnterEditMode,"(\""+gn+"\",\""+cell.id+"\");");
}

function igtbl_cancelNoOnBlurTA(gn)
{
	var textArea=igtbl_getElementById(gn+"_ta");
	if(textArea && textArea.style.display=="")
		textArea.removeAttribute("noOnBlur");
}

function igtbl_endCellEdit()
{
	if(this.webCombo != null)
	{
		var eCombo = this.webCombo.Element
		var cell=igtbl_getElementById(eCombo.getAttribute("currentCell"));
		if(!cell)
			return;
		var gn = this.Id;
		var gs=igtbl_getGridById(gn);
		var cellObj=igtbl_getCellById(cell.id);
		if(!this.webCombo.Prompt || this.webCombo.getSelectedIndex()>0)
			cellObj.setValue(this.webCombo.getDataValue());
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
		igcmbo_displaying=null;
		gs.exitEditCancel=false;
		eCombo.removeAttribute("currentCell");
		eCombo.removeAttribute("oldInnerText");
		gs.alignGrid();
		igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
		if(gs.NeedPostBack)
			igtbl_doPostBack(gn);
		this.webCombo = null;
		return;		
	}
}

function igtbl_dropDownListFocusOut(evnt,gn)
{
	var se=igtbl_srcElement(evnt);
	if(se.getAttribute("noOnBlur"))
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return false;
	}
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(!cell)
		return;
	var gs=igtbl_getGridById(gn);
	var cellObj=igtbl_getCellById(cell.id);
	if(se.options[se.selectedIndex].value!=cellObj.Column.ValueListPrompt)
		cellObj.setValue(se.options[se.selectedIndex].value);
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
	
	se.style.display="none";
	se.removeAttribute("currentCell");
	se.removeAttribute("oldInnerText");
	gs.alignGrid();
	igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn);
}

function igtbl_editBoxFocusOut(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	var se=igtbl_srcElement(evnt);
	if(se.getAttribute("noOnBlur") || gs.insideBeforeUpdate || se.getAttribute("invalidInput"))
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return false;
	}
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(!cell)
		return;
	var cellObj=igtbl_getCellById(cell.id);
	var textBoxValid=true;
	if(typeof(Page_Validators)!="undefined")
	{
		for(var j=0;j<cellObj.Column.Validators.length;j++)
			for(var i=0;i<Page_Validators.length;i++)
				if(Page_Validators[i].id==cellObj.Column.Validators[j])
				{
					ValidatorValidate(Page_Validators[i]);
					if(textBoxValid)
						textBoxValid=Page_Validators[i].isvalid;
				}
	}
	if(textBoxValid)
		cellObj.setValue(se.value);
	else
		se.setAttribute("invalidInput",true);
	if(!textBoxValid || igtbl_fireEvent(gn,gs.Events.BeforeExitEditMode,"(\""+gn+"\",\""+cell.id+"\")")==true)
	{
		if(!gs.exitEditCancel && !gs.insideSetActive)
		{
			gs.insideSetActive=true;
			igtbl_setActiveCell(gn,igtbl_getElementById(se.getAttribute("currentCell")));
			gs.insideSetActive=false;
		}
		gs.exitEditCancel=true;
		se.removeAttribute("invalidInput");
		return;
	}
	if(typeof(Page_Validators)!="undefined")
	{
		for(var i=0;i<Page_Validators.length;i++)
		{
			for(var j=0;j<cellObj.Column.Validators.length;j++)
				if(Page_Validators[i].id==cellObj.Column.Validators[j] && Page_Validators[i].enabled)
				{
					ValidatorEnable(Page_Validators[i],false);
					break;
				}
		}
	}
	gs.exitEditCancel=false;
	se.style.display="none";
	se.removeAttribute("invalidInput");
	se.removeAttribute("currentCell");
	se.removeAttribute("oldInnerText");
	gs.alignGrid();
	igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn);
}

function igtbl_editBoxMLFocusOut(evnt,gn)
{
	var se=igtbl_srcElement(evnt);
	if(se.getAttribute("noOnBlur"))
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return false;
	}
	var cell=igtbl_getElementById(se.getAttribute("currentCell"));
	if(!cell)
		return;
	var gs=igtbl_getGridById(gn);
	var cellObj=igtbl_getCellById(cell.id);
	cellObj.setValue(se.value);
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
	se.style.display="none";
	se.removeAttribute("currentCell");
	se.removeAttribute("oldInnerText");
	gs.alignGrid();
	igtbl_fireEvent(gn,gs.Events.AfterExitEditMode,"(\""+gn+"\",\""+cell.id+"\");");
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn);
}

function igtbl_onResize(gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs || gs.Element.getAttribute("noOnResize"))
		return;
	if(gs.ActiveCell!="")
		igtbl_setActiveCell(gn,igtbl_getElementById(gs.ActiveCell));
	else if(gs.ActiveRow!="")
		igtbl_setActiveRow(gn,igtbl_getElementById(gs.ActiveRow));
	igtbl_hideEdit(gn);
	if(gs.StatHeader)
		gs.StatHeader.ScrollTo(gs.Element.parentNode.scrollLeft);
	if(gs.StatFooter)
		gs.StatFooter.ScrollTo(gs.Element.parentNode.scrollLeft);
	gs.endEditTemplate();
}

function igtbl_isDisabled(elem)
{
	return elem.disabled;
}

function igtbl_setDisabled(elem,b)
{
	elem.disabled=b;
}

function igtbl_getStyleObj(name)
{
	for(var i=0;i<document.styleSheets.length;i++)
		for(var j=0;j<document.styleSheets[i].rules.length;j++)
			if(document.styleSheets[i].rules[j].selectorText=="."+name)
				return document.styleSheets[i].rules[j].style;
	return null;
}
