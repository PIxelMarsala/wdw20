
/* 
Infragistics UltraWebGrid Script 
Version 2.1.20033.4
Copyright (c) 2001-2003 Infragistics, Inc. All Rights Reserved.
*/

var igtbl_lastActiveGrid="";
var igtbl_needUpdate=false;

function igtbl_initGrid(gridId) 
{
	var gridElement = igtbl_getElementById("G_"+gridId);

	var grid = new igtbl_grid(gridElement,eval("igtbl_" + gridId + "_GridProps"),eval("igtbl_" + gridId + "_Events"));
	
	var bandsArray = eval("igtbl_" + gridId + "_Bands");
	var bandCount =  bandsArray.length;
	var i;
	grid.Bands = new Array(bandCount);
	for(var i = 0; i < bandCount; i++) 
	{
		grid.Bands[i] = new igtbl_band(grid, bandsArray[i], i.toString());
		var rs=grid.RowSelectors;
		if(grid.Bands[i].RowSelectors!=0)
			rs=grid.Bands[i].RowSelectors;
		if(bandCount==1)
		{
			if(rs==2)
				grid.Bands[i].firstActiveCell=0;
			else
				grid.Bands[i].firstActiveCell=1;
		}
		else
		{
			if(rs==2)
				grid.Bands[i].firstActiveCell=1;
			else
				grid.Bands[i].firstActiveCell=2;
		}
	}
	if(grid.sort)
	{
		for(var i=0;i<bandCount;i++) 
			for(var j=0;j<grid.Bands[i].Columns.length;j++)
			{
				grid.Bands[i].Columns[j].compareRows=igtbl_columnCompareRows;
				grid.Bands[i].Columns[j].compareCells=igtbl_columnCompareCells;
			}
	}
	grid.activeRect=(grid.activeRectId==""?null:igtbl_getElementById(grid.activeRectId));
	igtbl_gridState[gridId]=grid;
	
	if(!grid.Bands[0].IsGrouped)
	{
		if(grid.Bands[0].ColHeadersVisible!=2 && (grid.StationaryMargins==1 || grid.StationaryMargins==3))
			grid.StatHeader=new igtbl_initStatHeader(gridId);
		if(grid.Bands[0].ColFootersVisible==1 && (grid.StationaryMargins==2 || grid.StationaryMargins==3))
			grid.StatFooter=new igtbl_initStatFooter(gridId);
	}
	
	grid.Rows=new igtbl_initRowsCollection(null,grid,0);
	
	return grid;
}

function igtbl_getElementById(tagId) 
{
	var obj;
	if(document.all)
		obj=document.all[tagId];
	else
		obj=document.getElementById(tagId);
	if(obj && obj.length && obj[0].id==tagId)
		obj=obj[0];
	return obj;
}

function igtbl_getGridById(gridId) 
{
	if(typeof(igtbl_gridState)=="undefined")
		return null;
	if(!igtbl_gridState[gridId])
		return null;
	return igtbl_gridState[gridId];
}

function igtbl_getBandById(tagId) 
{
	if(!tagId)
		return null;
	var parts = tagId.split("_");
	var bandIndex = parts.length - 2;
	var gridId = parts[0];
	var el=igtbl_getElementById(tagId);
	if((gridId.charAt(gridId.length-3)=="g" && gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="c" || gridId.charAt(gridId.length-3)=="s" && gridId.charAt(gridId.length-2)=="g" && gridId.charAt(gridId.length-1)=="r") && el && el.getAttribute("groupRow"))
	{
		gridId=gridId.substr(0,gridId.length-3);
		bandIndex--;
	}
	else if(el && (gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="c" && el.tagName=="TD" || gridId.charAt(gridId.length-2)=="g" && gridId.charAt(gridId.length-1)=="r" && el.getAttribute("groupRow") || gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="h" && el.getAttribute("hiddenRow")))
	{
		gridId=gridId.substr(0,gridId.length-2);
		bandIndex--;
	}
	else if(gridId.charAt(gridId.length-1)=="r" && el && el.tagName=="TR")
		gridId=gridId.substr(0,gridId.length-1);
	else if(gridId.charAt(gridId.length-1)=="c" && el && el.tagName=="TH")
	{
		gridId=gridId.substr(0,gridId.length-1);
		bandIndex=parts[1];
	}
	else
		return null;
	if(!igtbl_getGridById(gridId))
		return null;
	var grid = igtbl_getGridById(gridId);
	return grid.Bands[bandIndex];
}

function igtbl_getColumnById(tagId) 
{
	if(!tagId)
		return null;
	var parts = tagId.split("_");
	var bandIndex = parts.length - 2;
	var gridId = parts[0];
	var el=igtbl_getElementById(tagId);
	if(gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="c" && el && el.tagName=="TD")
	{
		gridId=gridId.substr(0,gridId.length-2);
		bandIndex--;
	}
	else if(gridId.charAt(gridId.length-1)=="c")
	{
		if(el && el.tagName!="TH")
			return null;
		gridId=gridId.substr(0,gridId.length-1);
		bandIndex=parts[1];
	}
	else if(gridId.charAt(gridId.length-2)=="c" && gridId.charAt(gridId.length-1)=="g")
	{
		if(el && el.tagName!="DIV")
			return null;
		gridId=gridId.substr(0,gridId.length-2);
		bandIndex=parts[1];
	}
	else
		return null;
	if(!igtbl_getGridById(gridId))
		return null;
	var grid = igtbl_getGridById(gridId);
	var band = grid.Bands[bandIndex];
	var colIndex = parts[parts.length - 1];
	return band.Columns[colIndex];
}

function igtbl_getRowById(tagId) 
{
	if(!tagId)
		return null;
	var parts = tagId.split("_");
	var gridId = parts[0];
	var row=null;
	var isGrouped=false;
	if(gridId.charAt(gridId.length-3)=="g" && gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="c")
	{
		row=igtbl_getElementById(tagId);
		if(typeof(row)!="undefined" && row)
			row=row.parentNode;
		if(!row || !row.getAttribute("groupRow"))
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-3);
		isGrouped=true;
	}
	if(row==null && gridId.charAt(gridId.length-3)=="s" && gridId.charAt(gridId.length-2)=="g" && gridId.charAt(gridId.length-1)=="r")
	{
		row=igtbl_getWorkRow(igtbl_getElementById(tagId));
		if(!row || !row.getAttribute("groupRow"))
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-3);
		isGrouped=true;
	}
	if(row==null && gridId.charAt(gridId.length-2)=="g" && gridId.charAt(gridId.length-1)=="r")
	{
		row=igtbl_getElementById(tagId);
		if(!row || !row.getAttribute("groupRow"))
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-2);
		isGrouped=true;
	}
	if(row==null && gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="h")
	{
		row=igtbl_getElementById(tagId);
		if(typeof(row)!="undefined" && row)
			row=row.previousSibling;
		if(!row || !row.getAttribute("hiddenRow"))
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-2);
	}
	if(row==null && gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="c")
	{
		row=igtbl_getElementById(tagId);
		if(typeof(row)!="undefined" && row)
			row=row.parentNode;
		if(!row || row.tagName!="TR")
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-2);
	}
	if(row==null && gridId.charAt(gridId.length-1)=="r")
	{
		row=igtbl_getElementById(tagId);
		if(!row || row.tagName!="TR")
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-1);
	}
	if(row==null && gridId.charAt(gridId.length-1)=="l")
	{
		row=igtbl_getElementById(tagId);
		if(typeof(row)!="undefined" && row)
			row=row.parentNode;
		if(!row || row.tagName!="TR")
			row=null;
		else
			gridId=gridId.substr(0,gridId.length-1);
	}
	if(row==null)
		return null;
	var gs=igtbl_getGridById(gridId);
	if(!gs)
		return null;
	if(typeof(row.rowObject)!="undefined")
		return row.rowObject;
	else
	{
		parts=new Array();
		while(true)
		{
			var level=-1;
			for(var i=0;i<row.parentNode.childNodes.length;i++)
			{
				if(!row.parentNode.childNodes[i].getAttribute("hiddenRow"))
					level++;
				if(row.parentNode.childNodes[i]==row)
					break;
			}
			parts[parts.length]=level;
			if(row.parentNode.parentNode==gs.Element)
				break;
			row=row.parentNode.parentNode.parentNode.parentNode.previousSibling;
			row=igtbl_getWorkRow(row);
		}
		parts=parts.reverse();
		var rows=gs.Rows;
		for(var i=0;i<parts.length;i++)
		{
			row=rows.getRow(parseInt(parts[i],10));
			if(row && row.Expandable && i<parts.length-1)
				rows=row.Rows;
			else if(i<parts.length-1)
			{
				row=null;
				break;
			}
		}
		if(!row)
			return null;
		delete parts;
		row.Element.rowObject=row;
		return row;
	}
}

function igtbl_getCellById(tagId) 
{
	if(!tagId)
		return null;
	var parts = tagId.split("_");
	var gridId = parts[0];
	if(!(gridId.charAt(gridId.length-2)=="r" && gridId.charAt(gridId.length-1)=="c"))
		return null;
	gridId=gridId.substr(0,gridId.length-2);
	var gs=igtbl_getGridById(gridId);
	if(!gs)
		return null;
	var cellObj=igtbl_getElementById(tagId);
	if(!cellObj || cellObj.tagName!="TD")
		return null;
	var row=igtbl_getRowById(cellObj.parentNode.id);
	if(!row)
		return null;
	var column=row.Band.Columns[parseInt(parts[parts.length-1],10)];
	return row.getCellByColumn(column);
}

function igtbl_needPostBack(gn)
{
	igtbl_getGridById(gn).NeedPostBack=true;
}

function igtbl_cancelPostBack(gn)
{
	igtbl_getGridById(gn).CancelPostBack=true;
}

function igtbl_getCollapseImage(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var ci=g.CollapseImage;
	if(g.Bands[bandNo].CollapseImage!="")
		ci=g.Bands[bandNo].CollapseImage;
	return ci;
}

function igtbl_getExpandImage(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var ei=g.ExpandImage;
	if(g.Bands[bandNo].ExpandImage!="")
		ei=g.Bands[bandNo].ExpandImage;
	return ei;
}

function igtbl_getCellClickAction(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.CellClickAction;
	if(g.Bands[bandNo].CellClickAction!=0)
		res=g.Bands[bandNo].CellClickAction;
	return res;
}

function igtbl_getSelectTypeCell(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.SelectTypeCell;
	if(g.Bands[bandNo].SelectTypeCell!=0)
		res=g.Bands[bandNo].SelectTypeCell;
	return res;
}

function igtbl_getSelectTypeColumn(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.SelectTypeColumn;
	if(g.Bands[bandNo].SelectTypeColumn!=0)
		res=g.Bands[bandNo].SelectTypeColumn;
	return res;
}

function igtbl_getSelectTypeRow(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.SelectTypeRow;
	if(g.Bands[bandNo].SelectTypeRow!=0)
		res=g.Bands[bandNo].SelectTypeRow;
	return res;
}

function igtbl_getHeaderClickAction(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.HeaderClickAction;
	var band=g.Bands[bandNo];
	var column=band.Columns[columnNo];
	if(column.HeaderClickAction!=0)
		res=column.HeaderClickAction;
	else if(band.HeaderClickAction!=0)
		res=band.HeaderClickAction;
	if(res>1)
	{
		if(band.AllowSort!=0)
		{
			if(band.AllowSort==2)
				res=0;
		}
		else if(g.AllowSort==0 || g.AllowSort==2)
			res=0;
	}	
	return res;
}

function igtbl_getAllowUpdate(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.AllowUpdate;
	if(g.Bands[bandNo].AllowUpdate!=0)
		res=g.Bands[bandNo].AllowUpdate;
	if(typeof(columnNo)!="undefined" && g.Bands[bandNo].Columns[columnNo].AllowUpdate!=0)
		res=g.Bands[bandNo].Columns[columnNo].AllowUpdate;
	return res;
}

function igtbl_getAllowColSizing(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.AllowColSizing;
	if(g.Bands[bandNo].AllowColSizing!=0)
		res=g.Bands[bandNo].AllowColSizing;
	if(g.Bands[bandNo].Columns[columnNo].AllowColResizing!=0)
		res=g.Bands[bandNo].Columns[columnNo].AllowColResizing;
	return res;
}

function igtbl_getRowSizing(gn,bandNo,row)
{
	var g=igtbl_getGridById(gn);
	var res=g.RowSizing;
	if(g.Bands[bandNo].RowSizing!=0)
		res=g.Bands[bandNo].RowSizing;
	if(row.getAttribute("sizing"))
		res=parseInt(row.getAttribute("sizing"),10);
	return res;
}

function igtbl_getRowSelectors(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.RowSelectors;
	if(g.Bands[bandNo].RowSelectors!=0)
		res=g.Bands[bandNo].RowSelectors;
	return res;
}

function igtbl_getNullText(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].Columns[columnNo].NullText!="")
		return g.Bands[bandNo].Columns[columnNo].NullText;
	if(g.Bands[bandNo].NullText!="")
		return g.Bands[bandNo].NullText;
	return g.NullText;
}

function igtbl_getEditCellClass(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].EditCellClass!="")
		return g.Bands[bandNo].EditCellClass;
	return g.EditCellClass;
}

function igtbl_getFooterClass(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].FooterClass!="")
		return g.Bands[bandNo].FooterClass;
	return g.FooterClass;
}

function igtbl_getGroupByRowClass(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].GroupByRowClass!="")
		return g.Bands[bandNo].GroupByRowClass;
	return g.GroupByRowClass;
}

function igtbl_getHeadClass(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].HeaderClass!="")
		return g.Bands[bandNo].HeaderClass;
	return g.HeaderClass;
}

function igtbl_getRowLabelClass(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].RowLabelClass!="")
		return g.Bands[bandNo].RowLabelClass;
	return g.RowLabelClass;
}

function igtbl_getSelGroupByRowClass(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].SelGroupByRowClass!="")
		return g.Bands[bandNo].SelGroupByRowClass;
	return g.SelGroupByRowClass;
}

function igtbl_getSelHeadClass(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].Columns[columnNo].SelHeadClass!="")
		return g.Bands[bandNo].Columns[columnNo].SelHeadClass;
	if(g.Bands[bandNo].SelHeadClass!="")
		return g.Bands[bandNo].SelHeadClass;
	return g.SelHeadClass;
}

function igtbl_getSelCellClass(gn,bandNo,columnNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].Columns[columnNo].SelCellClass!="")
		return g.Bands[bandNo].Columns[columnNo].SelCellClass;
	if(g.Bands[bandNo].SelCellClass!="")
		return g.Bands[bandNo].SelCellClass;
	return g.SelCellClass;
}

function igtbl_getExpAreaClass(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	if(g.Bands[bandNo].ExpAreaClass!="")
		return g.Bands[bandNo].ExpAreaClass;
	return g.ExpAreaClass;
}

function igtbl_getCurrentRowImage(gn,bandNo)
{
	var g=igtbl_getGridById(gn);
	var res=g.CurrentRowImage;
	var band=g.Bands[bandNo];
	if(band.CurrentRowImage!="")
		res=band.CurrentRowImage;
	var au=igtbl_getAllowUpdate(gn,band.Index);
	if(band.RowTemplate!="" && (au==1 || au==3))
	{
		res=g.CurrentEditRowImage;
		if(band.CurrentEditRowImage!="")
			res=band.CurrentEditRowImage;
	}
	return res;
}

function igtbl_toggleRow(gn,srcRow,expand) 
{
	var sr = igtbl_getRowById(srcRow);
	if(!sr) return;
	if(!sr.getExpanded() && expand!=false) 
		sr.setExpanded(true);
	else if(expand!=true)
		sr.setExpanded(false);
}

function igtbl_selectStart(evnt) 
{
	evnt.cancelBubble = true;
	evnt.returnValue = false;
}

function igtbl_getBandFAC(gn,elem)
{
	var gs=igtbl_getGridById(gn);
	var bandNo=null;
	if(elem.tagName=="TD" || elem.tagName=="TH")
		bandNo=elem.parentNode.parentNode.parentNode.getAttribute("bandNo");
	else if(elem.tagName=="TR")
		bandNo=elem.parentNode.parentNode.getAttribute("bandNo");
	else if(elem.tagName=="TABLE")
		bandNo=elem.getAttribute("bandNo");
	if(bandNo)
		return gs.Bands[bandNo].firstActiveCell;
	return null;
}

function igtbl_headerClickDown(evnt,gn) 
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	igtbl_lastActiveGrid=gn;
	var te=gs.Element;
	te.setAttribute("mouseDown","1");
	var se=igtbl_srcElement(evnt);
	while(se && (se.tagName!="TH" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn) && (se.tagName!="DIV" || !se.getAttribute("groupInfo")))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName == "TH")
	{
		if(igtbl_fireEvent(gn,gs.Events.MouseDown,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")")==true)
			return true;
		if(igtbl_button(gn,evnt)!=0)
			return;
		var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
		var band=gs.Bands[bandNo];
		if(se.cellIndex>=band.firstActiveCell && igtbl_getOffsetX(evnt,se)>se.offsetWidth-4 && igtbl_getAllowColSizing(gn,bandNo,se.getAttribute("columnNo"))==2)
		{
			te.setAttribute("elementMode", "resize");
			te.setAttribute("resizeColumn", se.id);
			var cg;
			if(bandNo==0 && !band.IsGrouped && (gs.StationaryMargins==1 || gs.StationaryMargins==3))
				cg=te.childNodes[0];
			else
				cg=se.parentNode.parentNode.previousSibling;
			if(cg)
				for(var i=band.firstActiveCell;i<cg.childNodes.length;i++)
					if(cg.childNodes[i].offsetWidth>0)
						cg.childNodes[i].width=cg.childNodes[i].offsetWidth;
			return true;
		}
		se.setAttribute("justClicked",true);
		if(se.cellIndex>igtbl_getBandFAC(gn,se)-1)
		{
			if(igtbl_getHeaderClickAction(gn,bandNo,se.getAttribute("columnNo"))==1 && (gs.SelectedColumns[se.id]!=true || gs.ViewType!=2 || igtbl_getSelectTypeColumn(gn,bandNo)==3))
			{
				if(igtbl_getSelectTypeColumn(gn,bandNo)<2)
					return true;
				te.setAttribute("elementMode", "select");
				te.setAttribute("selectMethod", "column");
				if(!(igtbl_getSelectTypeColumn(gn,bandNo)==3 && evnt.ctrlKey))
					igtbl_clearSelectionAll(gn);
				if(te.getAttribute("shiftSelect") && evnt.shiftKey)
				{
					te.setAttribute("lastSelectedColumn","");
					igtbl_selectColumnRegion(gn,se);
					te.removeAttribute("shiftSelect");
				}
				else
				{
					te.setAttribute("startColumn", se.id);
					if(gs.SelectedColumns[se.id] && evnt.ctrlKey)
						igtbl_selectColumn(gn,se.id,false);
					else
						igtbl_selectColumn(gn,se.id);
					te.removeAttribute("shiftSelect", true);
					if(!evnt.ctrlKey)
						te.setAttribute("shiftSelect",true);
				}
				igtbl_needUpdate=true;
			}
		}
		return true;
	}
	else if(se.tagName=="DIV" && se.getAttribute("groupInfo"))
	{
		if(igtbl_button(gn,evnt)!=0)
			return;
		if(igtbl_fireEvent(gn,gs.Events.MouseDown,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")")==true)
			return;
		var groupInfo=se.getAttribute("groupInfo").split(":");
		if(groupInfo[0]!="band")
			igtbl_changeStyle(gn,se,igtbl_getSelHeadClass(gn,groupInfo[1],groupInfo[2]));
		se.setAttribute("justClicked",true);
		return true;
	}
}

function igtbl_headerClickUp(evnt,gn) 
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	if(igtbl_button(gn,evnt)==2)
		return;
	var te=gs.Element;
	te.removeAttribute("mouseDown");
	var se=igtbl_srcElement(evnt);
	while(se && (se.tagName!="TH" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn) && (se.tagName!="DIV" || !se.getAttribute("groupInfo")))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName == "TH")
	{
		var mode=te.getAttribute("elementMode");
		if(mode!="resize")
			igtbl_fireEvent(gn,gs.Events.ColumnHeaderClick,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")");
		if(igtbl_fireEvent(gn,gs.Events.MouseUp,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")")==true)
			return true;
		if(se.cellIndex>igtbl_getBandFAC(gn,se)-1)
		{
			if(igtbl_getHeaderClickAction(gn,se.parentNode.parentNode.parentNode.getAttribute("bandNo"),se.getAttribute("columnNo"))!=1)
				igtbl_changeStyle(gn,se,null);
			te.removeAttribute("elementMode");
			te.removeAttribute("resizeColumn");
			te.removeAttribute("selectMethod");
			if(!te.getAttribute("shiftSelect"))
				te.removeAttribute("startColumn");
			var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
			var columnNo=se.getAttribute("columnNo");
			var column=gs.Bands[bandNo].Columns[columnNo];
			if(mode!="resize" && (igtbl_getHeaderClickAction(gn,bandNo,columnNo)==2 || igtbl_getHeaderClickAction(gn,bandNo,columnNo)==3) && column.SortIndicator!=3)
			{
				if(gs.Bands[bandNo].ClientSortEnabled)
				{
					gs.startHourGlass();
					gs.sortingColumn=se;
					gs.oldColCursor=se.style.cursor;
					se.style.cursor="wait";
					window.setTimeout("igtbl_gridSortColumn('"+gn+"','"+se.id+"',"+evnt.shiftKey+")",1);
				}
				else
					gs.sortColumn(se.id,evnt.shiftKey);
				if(gs.NeedPostBack)
					igtbl_doPostBack(gn,"");
			}
			else
			{
				if(igtbl_needUpdate==true)
					igtbl_updatePostField(gn);
				if((mode=="resize" || mode=="select") && gs.NeedPostBack)
					igtbl_doPostBack(gn);
			}
		}
	}
	else if(se.tagName=="DIV" && se.getAttribute("groupInfo"))
	{
		igtbl_fireEvent(gn,gs.Events.ColumnHeaderClick,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")");
		if(igtbl_fireEvent(gn,gs.Events.MouseUp,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")")==true)
			return;
		var groupInfo=se.getAttribute("groupInfo").split(":");
		if(groupInfo[0]!="band")
		{
			igtbl_changeStyle(gn,se,null);
			var bandNo=igtbl_bandNoFromColId(se.id);
			var columnNo=igtbl_colNoFromColId(se.id);
			var column=gs.Bands[bandNo].Columns[columnNo];
			if((igtbl_getHeaderClickAction(gn,bandNo,columnNo)==2 || igtbl_getHeaderClickAction(gn,bandNo,columnNo)==3) && column.SortIndicator!=3)
			{
				if(gs.Bands[bandNo].ClientSortEnabled)
				{
					gs.startHourGlass();
					gs.sortingColumn=se;
					gs.oldColCursor=se.style.cursor;
					se.style.cursor="wait";
					window.setTimeout("igtbl_gridSortColumn('"+gn+"','"+se.id+"',true)",1);
				}
				else
					gs.sortColumn(se.id,evnt.shiftKey);
				if(gs.NeedPostBack)
					igtbl_doPostBack(gn,"");
			}
		}
	}
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn,'HeaderClick:'+se.id);
	return true;
}

function igtbl_headerContextMenu(evnt,gn) 
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	if(igtbl_button(gn,evnt)==2)
		return;
	var te=gs.Element;
	te.removeAttribute("mouseDown");
	var se=igtbl_srcElement(evnt);
	while(se && (se.tagName!="TH" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn) && (se.tagName!="DIV" || !se.getAttribute("groupInfo")))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName == "TH" || se.tagName == "DIV")
	{
		igtbl_fireEvent(gn,gs.Events.ColumnHeaderClick,"(\""+gn+"\",\""+se.id+"\",2)");
		if(igtbl_fireEvent(gn,gs.Events.MouseUp,"(\""+gn+"\",\""+se.id+"\",2)")==true)
		{
			evnt.cancelBubble=true;
			evnt.returnValue=false;
			return false;
		}
	}
}

function igtbl_gridSortColumn(gn,colId,shiftKey)
{
	var gs=igtbl_getGridById(gn);
	gs.sortColumn(colId,shiftKey);
	if(gs.sortingColumn && gs.oldColCursor);
		gs.sortingColumn.style.cursor=gs.oldColCursor;
	gs.stopHourGlass();
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn);
}

function igtbl_headerMouseOut(evnt,gn) 
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var se=igtbl_srcElement(evnt);
	if(se.tagName=="NOBR" && se.title)
		se.title="";
	if(se.tagName == "TH")
	{
		var sep=se.parentNode;
		if(gs.Element.getAttribute("elementMode")=="select")
			return true;
		if(igtbl_fireEvent(gn,gs.Events.MouseOut,"(\""+gn+"\",\""+se.id+"\",1)")==true)
			return true;
		if(se.cellIndex>igtbl_getBandFAC(gn,se)-1 && (igtbl_getHeaderClickAction(gn,sep.parentNode.parentNode.getAttribute("bandNo"),se.getAttribute("columnNo"))!=1))
			igtbl_changeStyle(gn,se,null);
		if(igtbl_needUpdate==true)
			igtbl_updatePostField(gn);
		return true;
	}
	else if(se.tagName == "DIV" && se.getAttribute("groupInfo"))
	{
		if(igtbl_fireEvent(gn,gs.Events.MouseOut,"(\""+gn+"\",\""+se.id+"\",1)")==true)
			return true;
		var groupInfo=se.getAttribute("groupInfo").split(":");
		if(groupInfo[0]!="band")
			igtbl_changeStyle(gn,se,null);
		return true;
	}
}

function igtbl_headerMouseOver(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var se=igtbl_srcElement(evnt);
	if(se.tagName=="NOBR")
	{
		var col=igtbl_getColumnById(se.parentNode.id);
		if(col)
		{
			var nobr=se;
			if(nobr.offsetWidth>se.parentNode.offsetWidth || nobr.offsetHeight>se.parentNode.offsetHeight)
				nobr.title=col.HeaderText;
		}
	}
	if(se.tagName!="DIV")
	{
		while(se && (se.tagName!="TH" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn))
			se=se.parentNode;
		if(!se)
			return;
	}
	if(se.tagName == "TH")
	{
		if(igtbl_fireEvent(gn,gs.Events.MouseOver,"(\""+gn+"\",\""+se.id+"\",1)")==true)
			return;
	}
	else if(se.tagName == "DIV" && se.getAttribute("groupInfo"))
	{
		if(igtbl_fireEvent(gn,gs.Events.MouseOver,"(\""+gn+"\",\""+se.id+"\",1)")==true)
			return;
	}
}

function igtbl_headerMouseMove(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return false;
	var se=igtbl_srcElement(evnt);
	while(se && (se.tagName!="TH" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn) && (se.tagName!="DIV" || !se.getAttribute("groupInfo")))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName == "TH")
	{
		var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
		if(igtbl_button(gn,evnt)==0)
		{
			var mode = gs.Element.getAttribute("elementMode");
			if(mode!=null && mode=="resize") 
			{
				var column = gs.Element.getAttribute("resizeColumn");
				if(!column)
					return;
				var resCol=igtbl_getElementById(column);
				resCol=igtbl_getElemVis(se.parentNode.childNodes,resCol.cellIndex);
				var cg;
				if(bandNo==0 && !gs.Bands[bandNo].IsGrouped && (gs.StationaryMargins==1 || gs.StationaryMargins==3))
					cg=gs.Element.childNodes[0];
				else
					cg=se.parentNode.parentNode.previousSibling;
				var co=resCol;
				if(cg)
					co=cg.childNodes[resCol.cellIndex];
				var c1w=co.offsetWidth+(evnt.clientX-(igtbl_getLeftPos(resCol)+co.offsetWidth));
				igtbl_resizeColumn(gn,resCol.id,c1w);
				var cursorName = se.getAttribute("oldCursor");
				if(cursorName == null)
					se.setAttribute("oldCursor", se.style.cursor);
				se.style.cursor="w-resize";
				igtbl_needUpdate=true;
			}
			else if(mode=="select" && se.cellIndex>igtbl_getBandFAC(gn,se)-1 && igtbl_getHeaderClickAction(gn,bandNo,se.getAttribute("columnNo"))==1 && !evnt.ctrlKey) 
				igtbl_selectColumnRegion(gn,se);
			else
			{
				var cursorName = se.getAttribute("oldCursor");
				if(cursorName != null)
				{
					se.style.cursor=cursorName;
					se.removeAttribute("oldCursor");
				}
				if(se.cellIndex>igtbl_getBandFAC(gn,se)-1 && (igtbl_getHeaderClickAction(gn,bandNo,se.getAttribute("columnNo"))!=1 || gs.SelectedColumns[se.id]==true || igtbl_getSelectTypeColumn(gn,bandNo)<2))
					if(gs.Bands[bandNo].Columns[se.getAttribute("columnNo")].AllowGroupBy==1 && gs.ViewType==2 && gs.GroupByBox.Element || gs.Bands[bandNo].AllowColumnMoving>1)
					{
						if(se.getAttribute("justClicked"))
						{
							if(typeof(igtbl_headerDragStart)!="undefined")
								igtbl_headerDragStart(gn,se,evnt);
						}
						else
							igtbl_changeStyle(gn,se,null);
					}
			}
		}
		else 
		{
			var te=gs.Element;
			te.removeAttribute("elementMode");
			te.removeAttribute("resizeColumn");
			te.removeAttribute("selectMethod");
			if(!te.getAttribute("shiftSelect"))
				te.removeAttribute("startColumn");
			if(se.cellIndex>=igtbl_getBandFAC(gn,se) && igtbl_getOffsetX(evnt,se)>se.offsetWidth-4 && igtbl_getAllowColSizing(gn,bandNo,se.getAttribute("columnNo"))==2)
			{
				var cursorName = se.getAttribute("oldCursor");
				if(cursorName == null)
					se.setAttribute("oldCursor", se.style.cursor);
				se.style.cursor="w-resize";
			}
			else if(se.cellIndex>=igtbl_getBandFAC(gn,se))
			{
				var cursorName = se.getAttribute("oldCursor");
				if(cursorName != null)
				{
					se.style.cursor=cursorName;
					se.removeAttribute("oldCursor");
				}
			}
		}
		if(se.getAttribute("justClicked"))
			se.removeAttribute("justClicked");
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return true;
	}
	else if(se.tagName == "DIV" && se.getAttribute("groupInfo"))
	{
		var groupInfo=se.getAttribute("groupInfo").split(":");
		if(groupInfo[0]!="band")
		{
			if(igtbl_button(gn,evnt)==0)
			{
				var cursorName = se.getAttribute("oldCursor");
				if(cursorName != null)
				{
					se.style.cursor=cursorName;
					se.removeAttribute("oldCursor");
				}
				igtbl_changeStyle(gn,se,null);
				if(gs.ViewType==2 && se.getAttribute("justClicked") && typeof(igtbl_headerDragStart)!="undefined")
					igtbl_headerDragStart(gn,se,evnt);
			}
		}
		if(se.getAttribute("justClicked"))
			se.removeAttribute("justClicked");
		return true;
	}
	return false;
}

function igtbl_tableMouseMove(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return false;
	var te=gs.Element;
	var se=igtbl_srcElement(evnt);
	if(igtbl_button(gn,evnt)==0 && te.getAttribute("elementMode")=="resize")
	{
		if((se.id==gn+"_div" || se.id==gn+"_hdiv" || se.tagName=="TABLE" && se.parentNode.parentNode.getAttribute("hiddenRow") || se.tagName=="TD" && se.parentNode.getAttribute("hiddenRow")) && te.getAttribute("resizeColumn"))
		{
			var column=te.getAttribute("resizeColumn");
			var resCol=igtbl_getElementById(column);
			var cg=se.childNodes[0];
			if(se.id==gn+"_div" || se.tagName=="TD")
				cg=cg.childNodes[0];
			else if(se.id==gn+"_hdiv")
				cg=cg.childNodes[0].childNodes[0];
			var co=cg.childNodes[resCol.cellIndex];
			var c1w=evnt.clientX-igtbl_getLeftPos(resCol);
			igtbl_resizeColumn(gn,resCol.id,c1w);
			if(evnt.cancelBubble)
				evnt.cancelBubble=true;
			if(evnt.returnValue)
				evnt.returnValue=false;
			return false;
		}
		else if(te.getAttribute("resizeRow") && (se.id==gn+"_div" || se.tagName=="TH" && se.parentNode.parentNode.tagName=="TFOOT" || se.tagName=="TD" && se.parentNode.getAttribute("hiddenRow")))
		{
			var rowId=te.getAttribute("resizeRow");
			var row=igtbl_getElementById(rowId);
			if(!row || row.getAttribute("hiddenRow"))
				return;
			var r1h=row.offsetHeight+(evnt.clientY-(igtbl_getTopPos(row)+row.offsetHeight));
			igtbl_resizeRow(gn,rowId,r1h);
			if(evnt.cancelBubble)
				evnt.cancelBubble=true;
			if(evnt.returnValue)
				evnt.returnValue=false;
			return false;
		}
	}
}

function igtbl_tableMouseUp(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return false;
	var se=igtbl_srcElement(evnt);
	if(se.id==gn+"_div" && gs.Element.getAttribute("elementMode")=="resize")
	{
		gs.Element.removeAttribute("elementMode");
		gs.Element.removeAttribute("resizeColumn");
	}
}

function igtbl_resizeColumn(gn,colId,width)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return false;
	var res=false;
	var col=igtbl_getColumnById(colId);
	var colObj=igtbl_getElementById(colId);
	var fac=igtbl_getBandFAC(gn,colObj);
	if(!colObj || colObj.cellIndex<fac)
		return res;
	var c1w=width;
	if(c1w>0)
	{
		var cancel=false;
		if(igtbl_fireEvent(gn,gs.Events.BeforeColumnSizeChange,"(\""+gn+"\",\""+colObj.id+"\","+c1w+")")==true)
			cancel=true;
		if(!cancel)
		{
			var columns=igtbl_getDocumentElement(colObj.id);
			if(columns.length)
				for(var i=0;i<columns.length;i++)
				{
					var cg;
					if(col.Band.Index==0 && !col.Band.IsGrouped && (gs.StationaryMargins==1 || gs.StationaryMargins==3))
						cg=gs.Element.childNodes[0];
					else
						cg=columns[i].parentNode.parentNode.previousSibling;
					if(cg)
						cg.childNodes[colObj.cellIndex].style.width=c1w;
					else
						columns[i].style.width=c1w;
				}
			else
			{
				var cg;
				if(col.Band.Index==0 && !col.Band.IsGrouped && (gs.StationaryMargins==1 || gs.StationaryMargins==3))
					cg=gs.Element.childNodes[0];
				else
					cg=colObj.parentNode.parentNode.previousSibling;
				if(cg)
					cg.childNodes[colObj.cellIndex].style.width=c1w;
				else
					colObj.style.width=c1w;
			}
			if(col.Band.Index==0)
			{
				if(gs.StatHeader)
					gs.StatHeader.ScrollTo(gs.Element.parentNode.scrollLeft);
				if(gs.StatFooter)
				{
					gs.StatFooter.Resize(colObj.cellIndex,c1w);
					gs.StatFooter.ScrollTo(gs.Element.parentNode.scrollLeft);
				}
			}
			gs.ResizedColumns[colObj.id]=c1w;
			if(gs.ActiveCell!="")
				igtbl_setActiveCell(gn,igtbl_getElementById(gs.ActiveCell));
			else if(gs.ActiveRow!="")
				igtbl_setActiveRow(gn,igtbl_getElementById(gs.ActiveRow));
			igtbl_fireEvent(gn,gs.Events.AfterColumnSizeChange,"(\""+gn+"\",\""+colObj.id+"\","+c1w+")");
		}
	}
	return res;
}

function igtbl_selectColumnRegion(gn,se)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var te=gs.Element;
	var lastSelectedColumn=te.getAttribute("lastSelectedColumn");
	var selMethod=te.getAttribute("selectMethod");
	if(selMethod=="column" && se.id!=lastSelectedColumn)
	{
		var startColumn=igtbl_getColumnById(te.getAttribute("startColumn"));
		if(startColumn==null)
			startColumn=igtbl_getColumnById(se.id);
		var endColumn=igtbl_getColumnById(se.id);
		if(igtbl_getSelectTypeColumn(gn,se.parentNode.parentNode.parentNode.getAttribute("bandNo"))==3)
			gs.selectColRegion(startColumn,endColumn);
		else
		{
			igtbl_clearSelectionAll(gn);
			igtbl_selectColumn(gn,se.id);
		}
		gs.Element.setAttribute("lastSelectedColumn",se.id);
	}
}

function igtbl_resizeRow(gn,rowId,height)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var row=igtbl_getRowById(rowId);
	if(!row)
		return;
	if(height>0)
	{
		var cancel=false;
		if(igtbl_fireEvent(gn,gs.Events.BeforeRowSizeChange,"(\""+gn+"\",\""+row.Element.id+"\","+height+")")==true)
			cancel=true;
		if(!cancel)
		{
			var rowLabel=null;
			if(!row.GroupByRow && igtbl_getRowSelectors(gn,row.Band.Index)!=2)
				rowLabel=row.Element.cells[row.Band.firstActiveCell-1];
			row.Element.style.height=height;
			gs.ResizedRows[row.Element.id]=height;
			if(rowLabel)
				rowLabel.style.height=height;
			gs.alignGrid();
			igtbl_fireEvent(gn,gs.Events.AfterRowSizeChange,"(\""+gn+"\",\""+row.Element.id+"\","+height+")");
		}
		igtbl_needUpdate=true;
	}
}

function igtbl_cellClickDown(evnt,gn) 
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	igtbl_lastActiveGrid=gn;
	gs.Element.setAttribute("mouseDown","1");
	var se=igtbl_srcElement(evnt);
	if(se.id==gn+"_vl" || se.id==gn+"_tb" || se.id==gn+"_ta")
		return;
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel && sel.style.display=="" && sel.getAttribute("noOnBlur"))
		return igtbl_cancelEvent(evnt);
	while(se && (se.tagName!="TD" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName == "TD") 
	{
		if(se.parentNode.parentNode.tagName=="TFOOT")
			return;
		if(igtbl_fireEvent(gn,gs.Events.MouseDown,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")")==true)
		{
			evnt.cancelBubble=true;
			return true;
		}
		var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
		if(igtbl_button(gn,evnt)==0 && se.cellIndex==igtbl_getBandFAC(gn,se)-1 && igtbl_getOffsetY(evnt,se)>se.offsetHeight-4 && igtbl_getRowSizing(gn,bandNo,se.parentNode)==2 && !se.getAttribute("groupRow"))
		{
			gs.Element.setAttribute("elementMode", "resize");
			gs.Element.setAttribute("resizeRow", se.parentNode.id);
			se.parentNode.style.height=se.parentNode.offsetHeight;
		}
		else if(se.cellIndex>=igtbl_getBandFAC(gn,se)-1 || se.getAttribute("groupRow"))
		{
			var te=gs.Element;
			var workTableId;
			if(se.getAttribute("groupRow"))
				workTableId=se.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.id;
			else
				workTableId=se.parentNode.parentNode.parentNode.id;
			if(igtbl_button(gn,evnt)!=0)
				return;
			if(workTableId=="")
				return;
			if(!se.getAttribute("groupRow") && se.cellIndex==igtbl_getBandFAC(gn,se)-1 && se.parentNode.cells[igtbl_getBandFAC(gn,se)].childNodes.length>0 && se.parentNode.cells[igtbl_getBandFAC(gn,se)].childNodes[0].tagName=="TABLE")
				return;
			te.removeAttribute("lastSelectedCell");
			var prevSelRow=gs.SelectedRows[igtbl_getWorkRow(se.parentNode).id];
			if(prevSelRow && igtbl_getLength(gs.SelectedRows)>1)
				prevSelRow=false;
			var selPresent=igtbl_getLength(gs.SelectedRows)>0 || igtbl_getLength(gs.SelectedCells)>0 || igtbl_getLength(gs.SelectedCols)>0;
			if(se.cellIndex==igtbl_getBandFAC(gn,se)-1 || igtbl_getCellClickAction(gn,bandNo)==2)
			{
				if(!(igtbl_getSelectTypeRow(gn,bandNo)==3 && evnt.ctrlKey))
					igtbl_clearSelectionAll(gn);
			}
			else
			{
				if(!(igtbl_getSelectTypeCell(gn,bandNo)==3 && evnt.ctrlKey))
					igtbl_clearSelectionAll(gn);
			}
			gs.Element.setAttribute("elementMode", "select");
			if(se.getAttribute("groupRow"))
			{
				te.setAttribute("selectTable", se.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.id);
				te.setAttribute("selectMethod", "row");
			}
			else
			{
				te.setAttribute("selectTable", se.parentNode.parentNode.parentNode.id);
				if(se.cellIndex==igtbl_getBandFAC(gn,se)-1 || igtbl_getCellClickAction(gn,bandNo)==2)
					te.setAttribute("selectMethod", "row");
				else
					te.setAttribute("selectMethod", "cell");
			}
			if(te.getAttribute("shiftSelect") && evnt.shiftKey)
			{
				igtbl_selectRegion(gn,se);
				te.removeAttribute("shiftSelect");
			}
			else
			{
				if(se.cellIndex==igtbl_getBandFAC(gn,se)-1 || igtbl_getCellClickAction(gn,bandNo)==2 || se.getAttribute("groupRow"))
				{
					if(gs.SelectedRows[se.parentNode.id] && evnt.ctrlKey)
						igtbl_selectRow(gn,igtbl_getWorkRow(se.parentNode).id,false);
					else
					{
						var showEdit=true;
						if(gs.activeRect)
						{
							if(gs.activeRect.getAttribute("srcElement")!=se.parentNode.id)
							{
								igtbl_setActiveRow(gn,se.parentNode);
								showEdit=false;
							}
							else
								showEdit=true;
						}
						if(!gs.exitEditCancel)
						{
							if(igtbl_getSelectTypeRow(gn,bandNo)>1)
								igtbl_selectRow(gn,igtbl_getWorkRow(se.parentNode).id,true,!prevSelRow);
							if(showEdit && !se.getAttribute("groupRow") && se.cellIndex==igtbl_getBandFAC(gn,se)-1)
								igtbl_getRowById(se.parentNode.id).editRow();
						}
					}
				}
				else
				{
					if(gs.SelectedCells[se.id] && evnt.ctrlKey)
						igtbl_selectCell(gn,se.id,false);
					else
					{
						igtbl_setActiveCell(gn,se);
						if(igtbl_getSelectTypeCell(gn,bandNo)>1 && igtbl_getCellClickAction(gn,bandNo)>=1 && !gs.exitEditCancel)
							igtbl_selectCell(gn,se.id);
						else if(selPresent)
							igtbl_fireEvent(gn,gs.Events.AfterSelectChange,"(\""+gn+"\",\""+se.id+"\");");
					}
				}
				if(se.getAttribute("groupRow"))
					te.setAttribute("startPointRow", se.parentNode.parentNode.parentNode.parentNode.parentNode.id);
				else
					te.setAttribute("startPointRow", se.parentNode.id);
				te.setAttribute("startPointCell", se.id);
				te.removeAttribute("shiftSelect", true);
				if(!evnt.ctrlKey)
					te.setAttribute("shiftSelect", true);
			}
			igtbl_updatePostField(gn);
		}
	}
	if(!igtbl_currentEditTempl)
		return igtbl_cancelEvent(evnt);
}

function igtbl_cellClickUp(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	if(igtbl_button(gn,evnt)==2)
		return;
	gs.Element.removeAttribute("mouseDown");
	var se=igtbl_srcElement(evnt);
	if(se.id==gn+"_vl" || se.id==gn+"_tb" || se.id==gn+"_ta")
		return;
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel && sel.style.display=="" && sel.getAttribute("noOnBlur"))
		return igtbl_cancelEvent(evnt);
	while(se && (se.tagName!="TD" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName != "TD")
		return;
	if(se.id == "")
		return;
	if(se.parentNode.parentNode.tagName=="TFOOT")
		return;
	var te=gs.Element;
	var mode=gs.Element.getAttribute("elementMode");
	gs.Element.removeAttribute("elementMode");
	te.removeAttribute("selectTable");
	te.removeAttribute("selectMethod");
	te.removeAttribute("resizeRow");
	if(!te.getAttribute("shiftSelect"))
	{
		te.removeAttribute("startPointRow");
		te.removeAttribute("startPointCell");
	}
	var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
	if(se.cellIndex>igtbl_getBandFAC(gn,se)-1 && igtbl_getCellClickAction(gn,bandNo)==1)
	{
		if(igtbl_getAllowUpdate(gn,bandNo)==3)
			igtbl_getRowById(se.parentNode.id).editRow();
		else
			igtbl_editCell(evnt,gn,se);
	}
	if(igtbl_needUpdate==true)
		igtbl_updatePostField(gn);
	if((mode=="resize" || mode=="select") && gs.NeedPostBack)
	{
		igtbl_doPostBack(gn);
		return;
	}
	if(!se.getAttribute("groupRow") && mode!="resize")
	{
		if(se.cellIndex==igtbl_getBandFAC(gn,se)-1)
			igtbl_fireEvent(gn,gs.Events.RowSelectorClick,"(\""+gn+"\",\""+se.parentNode.id+"\","+igtbl_button(gn,evnt)+")");
		else
			igtbl_fireEvent(gn,gs.Events.CellClick,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")");
	}
	if(igtbl_fireEvent(gn,gs.Events.MouseUp,"(\""+gn+"\",\""+se.id+"\","+igtbl_button(gn,evnt)+")")==true)
	{
		evnt.cancelBubble=true;
		return true;
	}
	if(gs.NeedPostBack && se.cellIndex==igtbl_getBandFAC(gn,se)-1)
		igtbl_doPostBack(gn,'RowClick:'+se.parentNode.id+(se.parentNode.getAttribute("level")?"\x05"+se.parentNode.getAttribute("level"):""));
	else if(gs.NeedPostBack && igtbl_getCellClickAction(gn,bandNo)==2)
		igtbl_doPostBack(gn,'RowClick:'+se.parentNode.id+(se.parentNode.getAttribute("level")?"\x05"+se.parentNode.getAttribute("level"):""));
	else if(gs.NeedPostBack)
		igtbl_doPostBack(gn,'CellClick:'+se.id+(se.getAttribute("level")?"\x05"+se.getAttribute("level"):""));
	return igtbl_cancelEvent(evnt);
}

function igtbl_cellContextMenu(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	gs.Element.removeAttribute("mouseDown");
	var se=igtbl_srcElement(evnt);
	if(se.id==gn+"_vl" || se.id==gn+"_tb" || se.id==gn+"_ta")
		return;
	while(se && (se.tagName!="TD" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName != "TD")
		return;
	if(se.id == "")
		return;
	if(se.parentNode.parentNode.tagName=="TFOOT")
		return;
	if(!se.getAttribute("groupRow"))
	{
		if(se.cellIndex==igtbl_getBandFAC(gn,se)-1)
			igtbl_fireEvent(gn,gs.Events.RowSelectorClick,"(\""+gn+"\",\""+se.parentNode.id+"\",2)");
		else
			igtbl_fireEvent(gn,gs.Events.CellClick,"(\""+gn+"\",\""+se.id+"\",2)");
	}
	if(igtbl_fireEvent(gn,gs.Events.MouseUp,"(\""+gn+"\",\""+se.id+"\",2)")==true)
	{
		evnt.cancelBubble=true;
		evnt.returnValue=false;
		return false;
	}
}

function igtbl_cellMouseOver(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var se=igtbl_srcElement(evnt);
	if(se.tagName=="NOBR")
	{
		var cell=igtbl_getCellById(se.parentNode.id);
		if(cell)
		{
			var nobr=cell.Element.childNodes[0];
			if(nobr.offsetWidth>cell.Element.offsetWidth || nobr.offsetHeight>cell.Element.offsetHeight)
				nobr.title=cell.getValue(true);
		}
		se=se.parentNode;
	}
	if(se.tagName != "TD" || se.id == "" || se.parentNode.parentNode.tagName=="TFOOT")
		return;
	if(igtbl_fireEvent(gn,gs.Events.MouseOver,"(\""+gn+"\",\""+se.id+"\",0)")==true)
		return;
}

function igtbl_cellMouseMove(evnt,gn)
{
	var se=igtbl_srcElement(evnt);
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var te=gs.Element;
	if(se.id==gn+"_vl" || se.id==gn+"_tb" || se.id==gn+"_ta")
		return;
	if(te.getAttribute("resizeRow") && (se.tagName=="TH" && se.parentNode.parentNode.tagName=="TFOOT" || se.tagName=="TD" && se.parentNode.getAttribute("hiddenRow")))
		return igtbl_tableMouseMove(evnt,gn);
	while(se && (se.tagName!="TD" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName != "TD")
		return;
	if(se.id == "")
		return;
	if(se.parentNode.parentNode.tagName=="TFOOT")
		return;
	var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
	if(igtbl_button(gn,evnt)==0)
	{
		var mode = te.getAttribute("elementMode");
		if(mode && mode=="resize") 
		{
			if(se.cellIndex!=igtbl_getBandFAC(gn,se)-1)
				return;
			var rowID = te.getAttribute("resizeRow");
			var row=igtbl_getElementById(rowID);
			if(!row || row.getAttribute("hiddenRow"))
				return;
			var r1h=row.offsetHeight+(evnt.clientY-(igtbl_getTopPos(row)+row.offsetHeight));
			igtbl_resizeRow(gn,rowID,r1h);
			var cursorName = se.getAttribute("oldCursor");
			if(cursorName==null)
				se.setAttribute("oldCursor", se.style.cursor);
			se.style.cursor="n-resize";
		}
		else
		{
			if(se.cellIndex==igtbl_getBandFAC(gn,se)-1)
			{
				var cursorName = se.getAttribute("oldCursor");
				if(cursorName!=null)
				{
					se.style.cursor=cursorName;
					se.removeAttribute("oldCursor");
				}
			}
			if(mode && mode=="select" && !evnt.ctrlKey) 
			{
				var lsc=te.getAttribute("lastSelectedCell");
				if(!lsc || lsc!=se.id)
					igtbl_selectRegion(gn,se);
				te.setAttribute("lastSelectedCell",se.id);
			}
		}
	}
	else if(igtbl_getOffsetY(evnt,se)>se.offsetHeight-4 && se.cellIndex==igtbl_getBandFAC(gn,se)-1 && igtbl_getRowSizing(gn,bandNo,se.parentNode)==2)
	{
		var cursorName = se.getAttribute("oldCursor");
		if(cursorName==null)
			se.setAttribute("oldCursor", se.style.cursor);
		se.style.cursor="n-resize";
		igtbl_colButtonMouseOut(gn);
	}
	else if(se.cellIndex==igtbl_getBandFAC(gn,se)-1)
	{
		var cursorName = se.getAttribute("oldCursor");
		if(cursorName!=null)
		{
			se.style.cursor=cursorName;
			se.removeAttribute("oldCursor");
		}
		igtbl_colButtonMouseOut(gn);
	}
	else 
	{
		var column=igtbl_getCellById(se.id);
		if(column)
			column=column.Column;
		if(column && !se.parentNode.getAttribute("groupRow") && column.Type==7 && column.CellButtonDisplay==0)
			igtbl_showColButton(gn,se);
		else
			igtbl_colButtonMouseOut(gn);
	}
	return false;
}

// Event handler for mouse out from cell
function igtbl_cellMouseOut(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var se=igtbl_srcElement(evnt);
	if(se.tagName=="NOBR")
	{
		var cell=igtbl_getCellById(se.parentNode.id);
		if(cell)
			cell.Element.childNodes[0].title="";
	}
	if(se.tagName!="TD" || se.parentNode.parentNode.tagName=="TFOOT")
		return;
	if(igtbl_fireEvent(gn,gs.Events.MouseOut,"(\""+gn+"\",\""+se.id+"\",0)")==true)
		return;
	if(igtbl_needUpdate==true)
		igtbl_updatePostField(gn);
}

function igtbl_cellDblClick(evnt,gn)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var se=igtbl_srcElement(evnt);
	if(se.id==gn+"_vl" || se.id==gn+"_tb" || se.id==gn+"_ta")
		return;
	while(se && (se.tagName!="TD" && se.tagName!="TH" || se.id.length<gn.length || se.id.substr(0,gn.length)!=gn))
		se=se.parentNode;
	if(!se)
		return;
	if(se.tagName!="TD" && se.tagName!="TH")
		return;
	if(se.parentNode.parentNode.tagName=="TFOOT")
		return;
	if(se.tagName=="TD")
	{
		if(se.getAttribute("groupRow"))
		{
			igtbl_toggleRow(gn,se.parentNode.id);
			return;
		}
		if(se.cellIndex<igtbl_getBandFAC(gn,se)-1)
			return;
		if(igtbl_fireEvent(gn,gs.Events.DblClick,"(\""+gn+"\",\""+se.id+"\")")==true)
			return;
		if(se.cellIndex==igtbl_getBandFAC(gn,se)-1)
		{
			if(gs.NeedPostBack)
				igtbl_doPostBack(gn,'RowDblClick:'+se.parentNode.id+(se.parentNode.getAttribute("level")?"\x05"+se.parentNode.getAttribute("level"):""));
			return;
		}
		var bandNo=se.parentNode.parentNode.parentNode.getAttribute("bandNo");
		if(gs.NeedPostBack)
		{
			if(igtbl_getCellClickAction(gn,bandNo)==2)
				igtbl_doPostBack(gn,'RowDblClick:'+se.parentNode.id+(se.parentNode.getAttribute("level")?"\x05"+se.parentNode.getAttribute("level"):""));
			else
				igtbl_doPostBack(gn,'CellDblClick:'+se.id+(se.getAttribute("level")?"\x05"+se.getAttribute("level"):""));
			return;
		}
		if(igtbl_getCellClickAction(gn,bandNo)==0)
			return;
		if(!gs.exitEditCancel)
		{
			if(igtbl_getAllowUpdate(gn,bandNo)==3)
				igtbl_getRowById(se.parentNode.id).editRow();
			else
				igtbl_editCell(evnt,gn,se);
		}
	}
	else
	{
		if(se.cellIndex<igtbl_getBandFAC(gn,se))
			return;
		if(igtbl_fireEvent(gn,gs.Events.DblClick,"(\""+gn+"\",\""+se.id+"\")")==true)
			return;
		if(gs.NeedPostBack)
			igtbl_doPostBack(gn,'HeaderDblClick:'+se.id);
	}
}

function igtbl_selectRegion(gn,se)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var rowContainer;
	if(!se)
		return;
	if(se.getAttribute("groupRow"))
		rowContainer=se.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
	else
		rowContainer=se.parentNode.parentNode;
	var te=gs.Element;
	var selTableId = te.getAttribute("selectTable");
	var workTableId;
	if(se.getAttribute("groupRow"))
		workTableId=se.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.id;
	else
		workTableId=se.parentNode.parentNode.parentNode.id;
	if(workTableId=="")
		return;
	var bandNo=igtbl_getElementById(workTableId).getAttribute("bandNo");
	if(selTableId==workTableId)
	{
		var selMethod = te.getAttribute("selectMethod");
		if(selMethod=="row" && (se.cellIndex==igtbl_getBandFAC(gn,se)-1 || igtbl_getCellClickAction(gn,bandNo)==2 && se.cellIndex>igtbl_getBandFAC(gn,se)-1 || se.getAttribute("groupRow")))
		{
			var selRow=igtbl_getRowById(te.getAttribute("startPointRow"));
			var rowId;
			if(se.getAttribute("groupRow"))
				rowId=se.parentNode.parentNode.parentNode.parentNode.parentNode.id;
			else
				rowId=se.parentNode.id;
			var curRow=igtbl_getRowById(rowId);
			if(igtbl_getSelectTypeRow(gn,bandNo)==3 && igtbl_getCellClickAction(gn,bandNo)>0)
			{
				gs.selectRowRegion(selRow,curRow);
				igtbl_setActiveRow(gn,curRow.FirstRow);
			}
			else
			{
				igtbl_clearSelectionAll(gn);
				if(se.getAttribute("groupRow"))
					rowId=igtbl_getWorkRow(se.parentNode).id;
				if(igtbl_getSelectTypeRow(gn,bandNo)>1 && igtbl_getCellClickAction(gn,bandNo)>0)
					igtbl_selectRow(gn,rowId);
				igtbl_setActiveRow(gn,igtbl_getFirstRow(igtbl_getElementById(rowId)));
			}
			igtbl_needUpdate=true;
		}
		else if(selMethod=="cell" && (se.cellIndex>igtbl_getBandFAC(gn,se)-1))
		{
			if(igtbl_getSelectTypeCell(gn,bandNo)==3 && igtbl_getCellClickAction(gn,bandNo)>0)
			{
				var selCell=igtbl_getCellById(te.getAttribute("startPointCell"));
				var curCell=igtbl_getCellById(se.id);
				gs.selectCellRegion(selCell,curCell);
				curCell.activate();
			}
			else
			{
				igtbl_clearSelectionAll(gn);
				if(igtbl_getSelectTypeCell(gn,bandNo)>1 && igtbl_getCellClickAction(gn,bandNo)>0)
					igtbl_selectCell(gn,se.id);
				igtbl_setActiveCell(gn,se);
			}	
			igtbl_needUpdate=true;
		}
	}
}

function igtbl_setSelectedRowImg(gn,row,hide)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	if(gs.currentTriImg!=null)
	{
		gs.lastSelectedRow=null;
		var imgObj;
		imgObj=document.createElement("img");
		imgObj.setAttribute("imgType","blank");
		imgObj.border="0";
		if(gs.RowLabelBlankImage)
			imgObj.src=gs.RowLabelBlankImage;
		else
		{
			imgObj.src=gs.BlankImage;
			imgObj.style.visibility="hidden";
		}
		gs.currentTriImg.parentNode.appendChild(imgObj);
		gs.currentTriImg.parentNode.removeChild(gs.currentTriImg);
		gs.currentTriImg=null;
	}
	if(!hide && row && !row.getAttribute("groupRow") && igtbl_getRowSelectors(gn,row.parentNode.parentNode.getAttribute("bandNo"))!=2)
	{
		var rl=row.cells[igtbl_getBandFAC(gn,row)-1];
		if(rl.childNodes.length==0 || !(rl.childNodes[0].tagName=="IMG" && rl.childNodes[0].getAttribute("imgType")=="newRow"))
		{
			var imgObj;
			imgObj=document.createElement("img");
			imgObj.src=igtbl_getCurrentRowImage(gn,row.parentNode.parentNode.getAttribute("bandNo"));
			imgObj.border="0";
			imgObj.setAttribute("imgType","tri");
			var cell=row.cells[igtbl_getBandFAC(gn,row)-1];
			cell.innerHTML="";
			cell.appendChild(imgObj);
			gs.currentTriImg=imgObj;
		}
		gs.lastSelectedRow=row.id;
	}
}

function igtbl_clearSelectionAll(gn)
{
	var gs=igtbl_getGridById(gn);
	if(igtbl_fireEvent(gn,gs.Events.BeforeSelectChange,"(\""+gn+"\",\"\")")==true)
		return;
	var row,column,cell;
	for(row in gs.SelectedRows)
	{
		igtbl_selectRow(gn,row,false,false);
		delete gs.SelectedRows[row];
	}
	for(column in gs.SelectedColumns)
	{
		igtbl_selectColumn(gn,column,false,false);
		delete gs.SelectedColumns[column];
	}
	for(cell in gs.SelectedCells)
	{
		igtbl_selectCell(gn,cell,false,false);
		delete gs.SelectedCells[cell];
	}
}

function igtbl_selectCell(gn,cellID,selFlag,fireEvent)
{
	var cell=igtbl_getElementById(cellID);
	if(!cell)
		return;
	var bandNo=cell.parentNode.parentNode.parentNode.getAttribute("bandNo");
	var columnNo=igtbl_getColumnNo(gn,cell);
	var gs=igtbl_getGridById(gn);
	if(gs.exitEditCancel || gs.noCellChange)
		return;
	if(igtbl_getSelectTypeCell(gn,bandNo)<2)
		return;
	if(igtbl_fireEvent(gn,gs.Events.BeforeSelectChange,"(\""+gn+"\",\""+cellID+"\")")==true)
		return;
	if(selFlag!=false)
	{
		igtbl_changeStyle(gn,cell,igtbl_getSelCellClass(gn,bandNo,columnNo));
		gs.SelectedCells[cellID]=true;
		cell.hideFocus=false;
	}
	else
	{
		delete gs.SelectedCells[cellID];
		if(!gs.SelectedColumns[igtbl_getColumnByCellId(cellID).id] && !gs.SelectedRows[cell.parentNode.id])
			igtbl_changeStyle(gn,cell,null);
	}
	if(fireEvent!=false)
	{
		igtbl_fireEvent(gn,gs.Events.AfterSelectChange,"(\""+gn+"\",\""+cellID+"\");");
		if(gs.NeedPostBack)
			igtbl_moveBackPostField(gn,"SelectedCells");
	}	
}

function igtbl_selectRow(gn,rowID,selFlag,fireEvent)
{
	var row=igtbl_getElementById(rowID);
	if(!row)
		return;
	var groupRow=row.getAttribute("groupRow");
	if(groupRow)
		row=igtbl_getFirstRow(row);
	var bandNo=row.parentNode.parentNode.getAttribute("bandNo");
	var gs=igtbl_getGridById(gn);
	if(igtbl_getSelectTypeRow(gn,bandNo)<2)
		return;
	if(gs.exitEditCancel || gs.noCellChange)
		return;
	if(fireEvent!=false)
		if(igtbl_fireEvent(gn,gs.Events.BeforeSelectChange,"(\""+gn+"\",\""+rowID+"\")")==true)
			return;
	if(selFlag!=false)
	{
		if(!groupRow)
			for(var i=igtbl_getBandFAC(gn,row);i<row.cells.length;i++)
			{
				var columnNo=igtbl_getColumnNo(gn,row.cells[i]);
				igtbl_changeStyle(gn,row.cells[i],igtbl_getSelCellClass(gn,bandNo,columnNo));
			}
		else
		{
			igtbl_changeStyle(gn,row.cells[0],igtbl_getSelGroupByRowClass(gn,row.parentNode.parentNode.getAttribute("bandNo")));
		}
		gs.SelectedRows[rowID]=true;
	}
	else
	{
		delete gs.SelectedRows[rowID];
		if(!row.getAttribute("groupRow"))
		{
			for(var i=igtbl_getBandFAC(gn,row);i<row.cells.length;i++)
				if(!gs.SelectedColumns[igtbl_getColumnByCellId(row.cells[i].id).id] && !gs.SelectedCells[row.cells[i].id])
					igtbl_changeStyle(gn,row.cells[i],null);
		}
		else
			igtbl_changeStyle(gn,row.cells[0],null);
	}
	if(fireEvent!=false)
	{
		igtbl_fireEvent(gn,gs.Events.AfterSelectChange,"(\""+gn+"\",\""+rowID+"\");");
		if(gs.NeedPostBack)
			igtbl_moveBackPostField(gn,"SelectedRows");
	}
}

function igtbl_selectColumn(gn,columnID,selFlag,fireEvent)
{
	var column=igtbl_getElementById(columnID);
	var bandNo=column.parentNode.parentNode.parentNode.getAttribute("bandNo");
	if(igtbl_getSelectTypeColumn(gn,bandNo)<2)
		return;
	var colNo=column.cellIndex;
	var gs=igtbl_getGridById(gn);
	if(gs.exitEditCancel || gs.noCellChange)
		return;
	if(fireEvent!=false)
		if(igtbl_fireEvent(gn,gs.Events.BeforeSelectChange,"(\""+gn+"\",\""+columnID+"\")")==true)
			return;
	if(selFlag!=false)
	{
		var cols=igtbl_getDocumentElement(columnID);
		if(cols.length)
			for(var j=0;j<cols.length;j++)
			{
				for(var i=1;i<cols[j].parentNode.parentNode.parentNode.rows.length;i++)
				{
					var row=cols[j].parentNode.parentNode.parentNode.rows[i];
					if(!row.getAttribute("hiddenRow") && row.parentNode.tagName!="TFOOT")
						igtbl_changeStyle(gn,igtbl_getElemVis(row.cells,colNo),igtbl_getSelCellClass(gn,bandNo,cols[j].getAttribute("columnNo")));
				}
				igtbl_changeStyle(gn,cols[j],igtbl_getSelHeadClass(gn,bandNo,cols[j].getAttribute("columnNo")));
			}
		else
		{
			for(var i=1;i<column.parentNode.parentNode.parentNode.rows.length;i++)
			{
				var row=column.parentNode.parentNode.parentNode.rows[i];
				if(!row.getAttribute("hiddenRow") && row.parentNode.tagName!="TFOOT")
					igtbl_changeStyle(gn,igtbl_getElemVis(row.cells,colNo),igtbl_getSelCellClass(gn,bandNo,column.getAttribute("columnNo")));
			}
			igtbl_changeStyle(gn,column,igtbl_getSelHeadClass(gn,bandNo,column.getAttribute("columnNo")));
		}
		gs.SelectedColumns[columnID]=true;
		igtbl_getColumnById(columnID).Selected=true;
		gs.Element.setAttribute("lastSelectedColumn",columnID);
	}
	else
	{
		var cols=igtbl_getDocumentElement(columnID);
		if(cols.length)
			for(var j=0;j<cols.length;j++)
			{
				igtbl_changeStyle(gn,cols[j],null);
				for(var i=1;i<cols[j].parentNode.parentNode.parentNode.rows.length;i++)
				{
					var row=cols[j].parentNode.parentNode.parentNode.rows[i];
					var cell=igtbl_getElemVis(row.cells,colNo);
					if(!row.getAttribute("hiddenRow") && !gs.SelectedRows[row.id] && !gs.SelectedCells[cell.id])
						igtbl_changeStyle(gn,cell,null);
				}
			}
		else
		{
			igtbl_changeStyle(gn,column,null);
			for(var i=1;i<column.parentNode.parentNode.parentNode.rows.length;i++)
			{
				var row=column.parentNode.parentNode.parentNode.rows[i];
				var cell=igtbl_getElemVis(row.cells,colNo);
				if(!row.getAttribute("hiddenRow") && !gs.SelectedRows[row.id] && !gs.SelectedCells[cell.id])
					igtbl_changeStyle(gn,cell,null);
			}
		}
		delete gs.SelectedColumns[columnID];
		igtbl_getColumnById(columnID).Selected=false;
	}
	if(fireEvent!=false)
	{
		igtbl_fireEvent(gn,gs.Events.AfterSelectChange,"(\""+gn+"\",\""+columnID+"\");");
		if(gs.NeedPostBack)
			igtbl_moveBackPostField(gn,"SelectedColumns");
	}
}

//Expands/collapses row in internal row structure
function igtbl_stateExpandRow(gn,rowID,expandFlag)
{
	var gs=igtbl_getGridById(gn);
	if(!gs)
		return;
	var row=igtbl_getElementById(rowID);
	if(row)
	{
		if(expandFlag)
		{
			gs.ExpandedRows[rowID]=true;
			if(gs.CollapsedRows[rowID])
				delete gs.CollapsedRows[rowID];
		}
		else
		{
			gs.CollapsedRows[rowID]=true;
			delete gs.ExpandedRows[rowID];
		}
	}
}

function igtbl_arrayHasElements(array)
{
	if(!array)
		return false;
	for(element in array)
		if(array[element]!=null)
			return true;
	return false;
}

function igtbl_getLeftPos(e,cc) 
{
    var x = e.offsetLeft;
    if(e.clientLeft && cc!=false)
	    x += e.clientLeft;
    var tmpE = e.offsetParent;
    while (tmpE != null) 
    {
		x += tmpE.offsetLeft;
		if((tmpE.tagName=="DIV" || tmpE.tagName=="TD") && tmpE.style.borderLeftWidth)
			x += parseInt(tmpE.style.borderLeftWidth);
		if(typeof(event)!="undefined" && tmpE.tagName!="BODY" && tmpE.scrollLeft)
			x-=tmpE.scrollLeft;
		else if(typeof(event)=="undefined" && tmpE.parentNode && tmpE.parentNode.tagName!="BODY" && tmpE.parentNode.scrollLeft)
			x-=tmpE.parentNode.scrollLeft;
		if(tmpE.clientLeft && cc!=false)
			x += tmpE.clientLeft;
        tmpE = tmpE.offsetParent;
    }
    return x;
}

function igtbl_getTopPos(e,cc) 
{
    var y = e.offsetTop;
    if(e.clientTop && cc!=false)
	    y += e.clientTop;
    var tmpE = e.offsetParent;
    while (tmpE != null) 
    {
		y += tmpE.offsetTop;
		if((tmpE.tagName=="DIV" || tmpE.tagName=="TD") && tmpE.style.borderTopWidth)
			y += parseInt(tmpE.style.borderTopWidth);
		if(typeof(event)!="undefined" && tmpE.tagName!="BODY" && tmpE.scrollTop)
			y-=tmpE.scrollTop;
		else if(typeof(event)=="undefined" && tmpE.parentNode && tmpE.parentNode.tagName!="BODY" && tmpE.parentNode.scrollTop)
			y-=tmpE.parentNode.scrollTop;
		if(tmpE.clientTop && cc!=false)
			y += tmpE.clientTop;
		tmpE = tmpE.offsetParent;
    }
    return y;
}

function igtbl_moveBackPostField(gn,param)
{
	var gs=igtbl_getGridById(gn);
	var p=igtbl_getElementById(gn);
	var postField=p.value;
	if(postField=="")
		return;
	var ar=postField.split("\04");
	for(var i=0;i<ar.length;i++)
	{
		var par=ar[i].split("\01");
		if(par[0]==param)
		{
			var pElem=ar[i];
			ar=ar.slice(0,i).concat(ar.slice(i+1),pElem);
			break;
		}
	}
	postField=ar.join("\04");
	p.value=postField;
}

function igtbl_updatePostField(gn,param)
{
	var postField="";
	var gs=igtbl_getGridById(gn);
	if(gs.SuspendUpdates)
		return;
	var g=gs.Element;
	var s="";
	var row=null;
	var p=igtbl_getElementById(gn);
	if(typeof(param)!="undefined")
	{
		postField=p.value;
		if(postField=="")
			return;
		var ar=postField.split("\04");
		for(var i=0;i<ar.length+1;i++)
		{
			var par;
			if(i<ar.length)
				par=ar[i].split("\01");
			if(i==ar.length || par[0]==param)
			{
				switch(param)
				{
				case "ScrollTop":
					if(g.parentNode.scrollTop)
						ar[i]="ScrollTop\01"+g.parentNode.scrollTop;
					break;
				case "ScrollLeft":
					if(g.parentNode.scrollLeft)
						ar[i]="ScrollLeft\01"+g.parentNode.scrollLeft;
					break;
				}
				break;
			}
		}
		postField=ar.join("\04");
	}
	else
	{
		for(row in gs.AddedRows)
		{
			var rowObj=igtbl_getElementById(row);
			if(gs.AddedRows[row]==true)
				s+=row+(rowObj && rowObj.getAttribute("level")?"\x05"+rowObj.getAttribute("level"):"")+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"AddedRows\01"+s.substr(0,s.length-1);
		s="";
		for(row in gs.SelectedRows)
		{
			var rowObj=igtbl_getElementById(row);
			if(rowObj && gs.SelectedRows[row]==true)
				s+=row+(rowObj.getAttribute("level")?"\x05"+rowObj.getAttribute("level"):"")+"\x03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"SelectedRows\01"+s.substr(0,s.length-1);
		s="";
		for(row in gs.ExpandedRows)
		{
			var rowObj=igtbl_getElementById(row);
			if(rowObj && gs.ExpandedRows[row]==true)
				s+=row+(rowObj.getAttribute("level")?"\x05"+rowObj.getAttribute("level"):"")+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"ExpandedRows\01"+s.substr(0,s.length-1);
		s="";
		for(row in gs.CollapsedRows)
		{
			var rowObj=igtbl_getElementById(row);
			if(rowObj && gs.CollapsedRows[row]==true)
				s+=row+(rowObj.getAttribute("level")?"\x05"+rowObj.getAttribute("level"):"")+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"CollapsedRows\01"+s.substr(0,s.length-1);
		s="";
		for(row in gs.ResizedRows)
		{
			var rowObj=igtbl_getElementById(row);
			if(rowObj)
				s+=row+(rowObj.getAttribute("level")?"\x05"+rowObj.getAttribute("level"):"")+"\02"+gs.ResizedRows[row]+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"ResizedRows\01"+s.substr(0,s.length-1);
		s="";
		for(column in gs.SelectedColumns)
		{
			columnObj=igtbl_getElementById(column);
			if(columnObj && gs.SelectedColumns[column]==true)
				s+=column+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"SelectedColumns\01"+s.substr(0,s.length-1);
		s="";
		for(column in gs.ResizedColumns)
			s+=column+"\02"+gs.ResizedColumns[column]+"\03";
		if(s!="")
			postField+=(postField!=""?"\04":"")+"ResizedColumns\01"+s.substr(0,s.length-1);
		s="";
		for(cell in gs.SelectedCells)
		{
			cellObj=igtbl_getElementById(cell);
			if(cellObj && gs.SelectedCells[cell]==true)
				s+=cell+(cellObj.getAttribute("level")?"\x05"+cellObj.getAttribute("level"):"")+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"SelectedCells\01"+s.substr(0,s.length-1);
		s="";
		for(cell in gs.ChangedCells)
		{
			cellObj=igtbl_getElementById(cell);
			if(cellObj)
				s+=cell+(cellObj.getAttribute("level")?"\x05"+cellObj.getAttribute("level"):"")+"\02"+gs.ChangedCells[cell]+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"ChangedCells\01"+s.substr(0,s.length-1);
		var ac=gs.ActiveCell;
		if(ac!="") 
		{
			var cellObj=igtbl_getElementById(ac);
			if(cellObj)
				postField+=(postField!=""?"\04":"")+"ActiveCell\01"+ac+(cellObj.getAttribute("level")?"\x05"+cellObj.getAttribute("level"):"");
		}
		else
		{
			var ar=gs.ActiveRow;
			if(ar!="") 
			{
				var rowObj=igtbl_getElementById(ar);
				if(rowObj)
					postField+=(postField!=""?"\04":"")+"ActiveRow\01"+ar+(rowObj.getAttribute("level")?"\x05"+rowObj.getAttribute("level"):"");
			}
		}
		s="";
		for(row in gs.DeletedRows)
		{
			if(gs.DeletedRows[row])
				s+=row+(gs.DeletedRows[row]!=true?"\x05"+gs.DeletedRows[row]:"")+"\03";
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"DeletedRows\01"+s.substr(0,s.length-1);
		s="";
		for(var i=0;i<gs.Bands.length;i++)
		{
			var band=gs.Bands[i];
			for(var j=0;j<band.SortedColumns.length;j++)
			{
				var col=band.SortedColumns[j];
				s+=col+"\02"+band.Columns[igtbl_colNoFromColId(col)].SortIndicator+"\02"+(col==gs.lastSortedColumn).toString()+"\03";
			}
		}
		if(s!="")
			postField+=(postField!=""?"\04":"")+"SortedColumns\01"+s.substr(0,s.length-1);
		if(g.parentNode.scrollLeft>0)
			postField+=(postField!=""?"\04":"")+"ScrollLeft\01"+g.parentNode.scrollLeft;
		if(g.parentNode.scrollTop>0)
			postField+=(postField!=""?"\04":"")+"ScrollTop\01"+g.parentNode.scrollTop;
	}
	p.value=postField;
	igtbl_needUpdate=false;
}

function igtbl_isVisible(elem)
{
	while(elem && elem.tagName!="BODY")
	{
		if(elem.style && elem.style.display=="none")
			return false;
		elem=elem.parentNode;
	}
	return true;
}

var igtbl_dontHandleChkBoxChange=false;

function igtbl_chkBoxChange(evnt,gn)
{
	if(igtbl_dontHandleChkBoxChange)
		return false;
	var se=igtbl_srcElement(evnt);
	var c=se.parentNode;
	while(c && !(c.tagName=="TD" && c.id!=""))
		c=c.parentNode;
	if(!c) return;
	var s=se;
	var cell=igtbl_getCellById(c.id);
	if(!cell) return;
	var column=cell.Column;
	var gs=igtbl_getGridById(gn);
	if(gs.exitEditCancel || !cell.isEditable() || igtbl_fireEvent(gn,gs.Events.BeforeCellUpdate,"(\""+gn+"\",\""+c.id+"\",\""+s.checked+"\")"))
	{
		igtbl_dontHandleChkBoxChange=true;
		s.checked=!s.checked;
		igtbl_dontHandleChkBoxChange=false;
		return true;
	}
	igtbl_saveChangedCell(gs,cell.Row.Element.id,c.id,s.checked.toString());
	if(!c.getAttribute("oldValue"))
		c.setAttribute("oldValue",s.checked);
	var cca=igtbl_getCellClickAction(gn,column.Band.Index);
	if(cca==1 || cca==3)
		igtbl_setActiveCell(gn,c);
	else if(cca==2)
		igtbl_setActiveRow(gn,c.parentNode);
	igtbl_updatePostField(gn);
	igtbl_fireEvent(gn,gs.Events.AfterCellUpdate,"(\""+gn+"\",\""+c.id+"\",\""+s.checked+"\")");
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn);
	return false;
}

function igtbl_colButtonClick(evnt,gn)
{
	var se=null;
	var b=igtbl_getElementById(gn+"_bt");
	if(b)
		se=igtbl_getElementById(b.getAttribute("srcElement"));
	if(typeof(se)=="undefined" || !se)
	{
		se=igtbl_srcElement(evnt).parentNode;
		if(se.tagName=="NOBR")
			se=se.parentNode;
	}
	var gs=igtbl_getGridById(gn);
	if(gs.exitEditCancel || typeof(se)=="undefined" || !se || se.id=="")
		return;
	igtbl_updatePostField(gn);
	igtbl_fireEvent(gn,gs.Events.ClickCellButton,"(\""+gn+"\",\""+se.id+"\")");
	if(gs.NeedPostBack)
		igtbl_doPostBack(gn,'CellButtonClick:'+se.id+(se.getAttribute("level")?"\x05"+se.getAttribute("level"):""));
}

function igtbl_colButtonMouseOut(gn)
{
	var b=igtbl_getElementById(gn+"_bt");
	if(!b)
		return;
	if(b.getAttribute("noOnBlur"))
		return;
	if(b.style.display=="")
	{
		b.setAttribute("noOnBlur",true);
		b.style.display="none";
		b.removeAttribute("srcElement");
		var gs=igtbl_getGridById(gn);
		if(!gs.activeRect)
			return;
		var se=igtbl_getElementById(gs.activeRect.getAttribute("srcElement"));
		if(se && gs.ActiveCell!="")
		{
			var column=gs.Bands[se.parentNode.parentNode.parentNode.getAttribute("bandNo")].Columns[igtbl_getColumnNo(gn,se)];
			if(gs.ActiveCell!="" && se && !se.parentNode.getAttribute("groupRow") && column.Type==7 && column.CellButtonDisplay==0)
				igtbl_showColButton(gn,se);
			else if(se && igtbl_isVisible(se))
				gs.activeRect.style.display="";
		}
		else if(se && igtbl_isVisible(se))
				gs.activeRect.style.display="";
		window.setTimeout("igtbl_clearNoOnBlurBtn('"+gn+"')",100);
	}
}

function igtbl_clearNoOnBlurBtn(gn)
{
	var b=igtbl_getElementById(gn+"_bt");
	b.removeAttribute("noOnBlur");
}

function igtbl_getColumnNo(gn,cell)
{
	if(cell)
	{
		var column=igtbl_getColumnById(cell.id);
		if(column)
			return column.Index;
		else
			return -1;
	}
}

function igtbl_getBandNo(gn,cell)
{
	if(cell)
		return parseInt(cell.parentNode.parentNode.parentNode.getAttribute("bandNo"));
}

function igtbl_getFirstRow(row)
{
	if(row.getAttribute("groupRow"))
		return row.childNodes[0].childNodes[0].childNodes[0].rows[0];
	else
		return row;
}

function igtbl_getWorkRow(row)
{
	if(row.getAttribute("groupRow"))
	{
		var id=row.id.split("_");
		if(id[0].length>3 && id[0].substr(id[0].length-3)=="sgr")
			return row.parentNode.parentNode.parentNode.parentNode;
		else
			return row;
	}
	else
		return row;
}

function igtbl_getCurCell(se)
{
	var c=null;
	while(se && !c) 
		if(se.tagName=="TD")
			c=se;
		else
			se=se.parentNode;
	return c;
}

function igtbl_getColumnByCellId(cellID)
{
	var cell=igtbl_getCellById(cellID);
	if(!cell)
		return null;
	if(cell.Band.Index==0 && !cell.Band.IsGrouped && cell.Band.ColHeadersVisible==1 && (cell.Band.Grid.StationaryMargins==1 || cell.Band.Grid.StationaryMargins==3))
		return igtbl_getElemVis(cell.Band.Grid.StatHeader.Element.rows[0].cells,cell.Element.cellIndex);
	if(cell.Element.parentNode.parentNode.parentNode.childNodes[1].tagName=="THEAD")
		return igtbl_getElemVis(cell.Element.parentNode.parentNode.parentNode.childNodes[1].rows[0].cells,cell.Element.cellIndex);
	return null;
}

function igtbl_colButtonEvent(evnt,gn)
{
	var se=null;
	var b=igtbl_getElementById(gn+"_bt");
	if(b)
		se=igtbl_getElementById(b.getAttribute("srcElement"));
	else
		se=igtbl_srcElement(evnt).parentNode;
	if(!se || se.id=="")
		return;
	evnt.returnValue=false;
	se.fireEvent("on"+evnt.type,evnt);
}

function igtbl_isCell(itemName)
{
	var parts = itemName.split("_");
	if(parts[0].charAt(parts[0].length-2)=="r" && parts[0].charAt(parts[0].length-1)=="c")
		return true;
	return false;
}

function igtbl_isColumnHeader(itemName)
{
	var parts = itemName.split("_");
	if(parts[0].charAt(parts[0].length-1)=="c" && !igtbl_isCell(itemName))
		return true;
	return false;
}

function igtbl_isRowLabel(itemName)
{
	var parts = itemName.split("_");
	if(parts[0].charAt(parts[0].length-1)=="l")
		return true;
	return false;
}

function igtbl_fireEvent(gn,eventObj,eventString)
{
	var gs=igtbl_getGridById(gn);
	if(!gs || !gs.GridIsLoaded) return;
	var result=false;
	if(eventObj[0]!="")
		result=eval(eventObj[0]+eventString);
	if(gs.GridIsLoaded && result!=true && eventObj[1]==1 && !gs.CancelPostBack)
		igtbl_needPostBack(gn);
	gs.CancelPostBack=false;
	return result;
}

function igtbl_dropDownChange(evnt,gn)
{
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel)
		igtbl_fireEvent(gn,igtbl_getGridById(gn).Events.ValueListSelChange,"(\""+gn+"\",\""+gn+"_vl\",\""+sel.getAttribute("currentCell")+"\");");
}

function igtbl_inEditMode(gn)
{
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel && sel.style.display=="")
		return true;
	var tb=igtbl_getElementById(gn+"_tb");
	if(tb && tb.style.display=="")
		return true;
	var ta=igtbl_getElementById(gn+"_ta");
	if(ta && ta.style.display=="")
		return true;
	return false;
}

function igtbl_bandNoFromColId(colId)
{
	var s=colId.split("_");
	if(s.length<3)
		return null;
	return parseInt(s[s.length-2]);
}

function igtbl_colNoFromColId(colId)
{
	var s=colId.split("_");
	if(s.length<3)
		return null;
	return parseInt(s[s.length-1]);
}

function igtbl_colNoFromId(id)
{
	if(!id)
		return null;
	var s=id.split("_");
	if(s.length==0)
		return null;
	return parseInt(s[s.length-1]);
}

function igtbl_doPostBack(gn,args)
{
	var gs=igtbl_getGridById(gn);
	if(gs.GridIsLoaded && !gs.CancelPostBack)
	{
		gs.GridIsLoaded=false;
		if(!args)
			args="";
		igtbl_submit();
		__doPostBack(gs.UniqueID,args);
	}
}

function igtbl_scrollToView(gn,child)
{
	if(!child)
		return;
	var parent=igtbl_getGridById(gn).Element.parentNode;
	if(parent.scrollWidth<=parent.offsetWidth && parent.scrollHeight<=parent.offsetHeight)
		return;
	var childLeft=igtbl_getLeftPos(child);
	var parentLeft=igtbl_getLeftPos(parent);
	var childTop=igtbl_getTopPos(child);
	var parentTop=igtbl_getTopPos(parent);
	var childRight=childLeft+child.offsetWidth;
	var parentRight=parentLeft+parent.offsetWidth;
	var childBottom=childTop+child.offsetHeight;
	var parentBottom=parentTop+parent.offsetHeight;
	var hsw=(parent.scrollWidth>parent.offsetWidth?18:0)
	var vsw=(parent.scrollWidth>parent.offsetWidth || parent.scrollHeight>parent.offsetHeight?18:0)
	if(childRight>parentRight-vsw && childLeft-(childRight-parentRight)>parentLeft)
		parent.scrollLeft+=childRight-parentRight+vsw;
	if(childBottom>parentBottom-hsw && childTop-(parentTop-childTop)>parentTop)
		parent.scrollTop+=childBottom-parentBottom+hsw;
	if(childLeft<parentLeft)
		parent.scrollLeft-=parentLeft-childLeft;
	if(childTop<parentTop)
		parent.scrollTop-=parentTop-childTop;
}

function igtbl_sortColumn(colId,shiftKey)
{
	var bandNo=igtbl_bandNoFromColId(colId);
	var band=this.Bands[bandNo];
	var colNo=igtbl_colNoFromColId(colId);
	if(band.Columns[colNo].SortIndicator==3)
		return;
	var headClk=igtbl_getHeaderClickAction(this.Id,bandNo,colNo);
	if(headClk==2 || headClk==3)
	{
		var gs=igtbl_getGridById(this.Id);
		var eventCanceled=igtbl_fireEvent(this.Id,this.Events.BeforeSortColumn,"(\""+this.Id+"\",\""+colId+"\")");
		if(eventCanceled && band.ClientSortEnabled)
			return;
		this.addSortColumn(colId,(headClk==2 || !shiftKey));
		igtbl_updatePostField(this.Id);
		if(!eventCanceled && band.ClientSortEnabled)
		{
			this.sort();
			igtbl_hideEdit(this.Id);
			if(gs.ActiveCell!="")
			{
				var ac=igtbl_getElementById(gs.ActiveCell);
				igtbl_setActiveCell(this.Id,ac);
			}
			else if(gs.ActiveRow!="")
				igtbl_setActiveRow(this.Id,igtbl_getElementById(gs.ActiveRow));
			igtbl_fireEvent(this.Id,this.Events.AfterSortColumn,"(\""+this.Id+"\",\""+colId+"\")");
		}
		else if(!band.ClientSortEnabled)
			gs.NeedPostBack=true;
	}
}

function igtbl_addSortColumn(colId,clear)
{
	var colAr=colId.split(";");
	if(colAr.length>1)
	{
		for(var i=0;i<colAr.length;i++)
			if(colAr[i]!="")
			{
				var band=this.Bands[igtbl_bandNoFromColId(colAr[i])];
				band.SortedColumns[band.SortedColumns.length]=colAr[i];
			}
	}
	else
	{
		var band=this.Bands[igtbl_bandNoFromColId(colId)];
		var colNo=igtbl_colNoFromColId(colId);
		if(band.Columns[colNo].SortIndicator==3)
			return;
		if(clear)
		{
			var scLen=band.SortedColumns.length;
			for(var i=scLen-1;i>=0;i--)
			{
				var cn=igtbl_colNoFromColId(band.SortedColumns[i]);
				if(cn!=colNo && band.Columns[cn].SortIndicator!=3 && !band.Columns[cn].IsGroupBy)
				{
					band.Columns[cn].SortIndicator=0;
					if(band.ClientSortEnabled)
					{
						var colEl=igtbl_getDocumentElement(band.SortedColumns[i]);
						if(colEl.length)
						{
							for(var j=0;j<colEl.length;j++)
							{
								var img=null;
								var el=colEl[j];
								if(el.childNodes.length && el.childNodes[0].tagName=="NOBR")
									el=el.childNodes[0];
								if(el.childNodes.length && el.childNodes[el.childNodes.length-1].tagName=="IMG" && el.childNodes[el.childNodes.length-1].getAttribute("imgType")=="sort")
									img=el.childNodes[el.childNodes.length-1];
								if(img)
									el.removeChild(img);
							}
						}
						else
						{
							var img=null;
							var el=colEl;
							if(el.childNodes.length && el.childNodes[0].tagName=="NOBR")
								el=el.childNodes[0];
							if(el.childNodes.length && el.childNodes[el.childNodes.length-1].tagName=="IMG" && el.childNodes[el.childNodes.length-1].getAttribute("imgType")=="sort")
								img=el.childNodes[el.childNodes.length-1];
							if(img)
								el.removeChild(img);
						}
					}
				}
				if(band.Columns[cn].IsGroupBy)
					break;
				band.SortedColumns=band.SortedColumns.slice(0,-1);
			}
		}
		if(band.Columns[colNo].SortIndicator==1)
			band.Columns[colNo].SortIndicator=2;
		else
			band.Columns[colNo].SortIndicator=1;
		band.Grid.lastSortedColumn=colId;
		if(band.ClientSortEnabled)
		{
			var colEl=igtbl_getDocumentElement(colId);
			if(colEl.length)
			{
				for(var i=0;i<colEl.length;i++)
				{
					var img=null;
					var el=colEl[i];
					if(el.childNodes.length && el.childNodes[0].tagName=="NOBR")
						el=el.childNodes[0];
					if(el.childNodes.length && el.childNodes[el.childNodes.length-1].tagName=="IMG" && el.childNodes[el.childNodes.length-1].getAttribute("imgType")=="sort")
						img=el.childNodes[el.childNodes.length-1];
					else
					{
						img=document.createElement("img");
						img.border="0";
						img.setAttribute("imgType","sort");
						el.appendChild(img);
					}
					if(band.Columns[colNo].SortIndicator==1)
						img.src=this.SortAscImg;
					else
						img.src=this.SortDscImg;
				}
			}
			else
			{
				var img=null;
				var el=colEl;
				if(el.childNodes.length && el.childNodes[0].tagName=="NOBR")
					el=el.childNodes[0];
				if(el.childNodes.length && el.childNodes[el.childNodes.length-1].tagName=="IMG" && el.childNodes[el.childNodes.length-1].getAttribute("imgType")=="sort")
					img=el.childNodes[el.childNodes.length-1];
				else
				{
					img=document.createElement("img");
					img.border="0";
					img.setAttribute("imgType","sort");
					el.appendChild(img);
				}
				if(band.Columns[colNo].SortIndicator==1)
					img.src=this.SortAscImg;
				else
					img.src=this.SortDscImg;
			}
		}
		if(!band.Columns[colNo].IsGroupBy)
		{
			for(var i=0;i<band.SortedColumns.length;i++)
				if(band.SortedColumns[i]==colId)
					break;
			if(i==band.SortedColumns.length)
				band.SortedColumns[band.SortedColumns.length]=colId;
		}
	}
}

function igtbl_unloadRows(Rows)
{
	if(Rows.rows.length)
		for(var i=Rows.rows.length-1;i>=0;i--)
		{
			var row=Rows.rows[i];
			if(row)
			{
				if(row.Rows)
				{
					igtbl_unloadRows(row.Rows);
				}
				if(row.cells)
				{
					for(var j=0;row.cells.length && j<row.cells.length;j++)
						delete row.cells[j];
					delete row.cells
				}
				delete Rows.rows[i];
			}
		}
	delete Rows.rows;
	if(Rows.deletedRows)
		delete Rows.deletedRows;
	delete Rows;
}

function igtbl_unloadGrid(gn)
{
	var gs = igtbl_getGridById(gn);
	igtbl_unloadRows(gs.Rows);
	delete gs.Rows;
	var bands = gs.Bands;
	var bandCount = bands.length;
	for(var i = 0; i < bandCount; i++) {
		var band = bands[i];
		var columns = band.Columns;
		var colCount = columns.length;
		for(var j = 0; j < colCount; j++) {
			var column = columns[j];
			delete column;
		}
		if(band.ExpandEffects)
			delete band.ExpandEffects;
		delete band.SortedColumns;
		delete band.Columns;
		delete band;
	}
	gs.Element = null;
	delete gs.Bands;
	if(gs.StatHeader)
		delete gs.StatHeader;
	if(gs.StatFooter)
		delete gs.StatFooter;
	delete gs.Events;
	if(gs.GroupByBox)
	{
		if(gs.GroupByBox.groups)
		{
			for(var i=0;i<gs.GroupByBox.groups.length;i++)
				delete gs.GroupByBox.groups[i];
			delete gs.GroupByBox.groups;
		}
		delete gs.GroupByBox;
	}
	delete gs.SelectedRows;
	delete gs.SelectedColumns;
	delete gs.SelectedCells;
	delete gs.ExpandedRows;
	delete gs.CollapsedRows;
	delete gs.ResizedColumns;
	delete gs.ResizedRows;
	delete gs.ChangedCells;
	var row=null;
	for(row in gs.ChangedRows)
		delete row;
	delete gs.ChangedRows;
	delete gs.AddedRows;
	delete gs.DeletedRows;
	delete gs;
	if(igtbl_gridState.length==0)
		delete igtbl_gridState;
}

function igtbl_getElemVis(cols,index)
{
	var i=0,j=-1;
	while(cols && cols[i] && j!=index)
	{
		if(cols[i].style.display!="none")
			j++;
		i++;
	}
	return cols[i-1];
}

function igtbl_trim(s)
{
	if(!s)
		return s;
	s=s.toString();
	var result=s;
	for(var i=0;i<s.length;i++)
		if(s.charAt(i)!=' ')
			break;
	result=s.substr(i,s.length-i);
	for(var i=result.length-1;i>=0;i--)
		if(result.charAt(i)!=' ')
			break;
	result=result.substr(0,i+1);
	return result;
}

function igtbl_cancelNoOnBlurTB(gn)
{
	var textBox=igtbl_getElementById(gn+"_tb");
	if(textBox && textBox.style.display=="")
		textBox.removeAttribute("noOnBlur");
	var sel=igtbl_getElementById(gn+"_vl");
	if(sel && sel.style.display=="")
		sel.removeAttribute("noOnBlur");
}

function igtbl_cancelNoOnBlurDD(gn)
{
	if(arguments.length==0)
		gn=igtbl_lastActiveGrid;
	var gs=igtbl_getGridById(gn);
	if(gs && gs.editorControl)
		gs.editorControl.Element.removeAttribute("noOnBlur");
}

function igtbl_getChildRows(gn,row)
{
	var rows;
	if(row.getAttribute("groupRow"))
		rows=row.childNodes[0].childNodes[0].childNodes[0].rows[1].childNodes[0].childNodes[0].tBodies[0].rows;
	else
	{
		if(row.nextSibling && row.nextSibling.getAttribute("hiddenRow"))
			rows=row.nextSibling.childNodes[igtbl_getBandFAC(gn,row)].childNodes[0].tBodies[0].rows;
		else
			rows=null;
	}
	return rows;
}

function igtbl_rowsCount(rows)
{
	var i=0,j=0;
	while(j<rows.length)
		if(!rows[j++].getAttribute("hiddenRow"))
			i++;
	return i;
}

function igtbl_visRowsCount(rows)
{
	var i=0,j=0;
	while(j<rows.length)
	{
		if(!rows[j].getAttribute("hiddenRow") && rows[j].style.display=="")
			i++;
		j++;
	}
	return i;
}

var igtbl_oldOnUnload;

function igtbl_submit()
{
	if(window.onunload!=igtbl_unload)
	{
	//	for(var gridId in igtbl_gridState)
	//		igtbl_updatePostField(gridId);
		igtbl_oldOnUnload=window.onunload;
		window.onunload=igtbl_unload;
	}
}

function igtbl_unload()
{
	if(igtbl_oldOnUnload)
		igtbl_oldOnUnload();
	for(var gridId in igtbl_gridState)
		igtbl_gridState[gridId].unloadGrid();
}

function igtbl_cancelEvent(evnt)
{
	if(typeof(event)!="undefined")
	{
		event.cancelBubble=true;
		event.returnValue=false;
		return true;
	}
	else
	{
		evnt.stopPropagation();
		evnt.preventDefault();
		return false;
	}
}

function igtbl_getRegExpSafe(val)
{
	if(typeof(val)=="undefined" || val==null)
		return "";
	var res=val.toString().replace("\\","\\\\");
	res=res.replace("^","\\^");
	res=res.replace("*","\\*");
	res=res.replace("$","\\$");
	res=res.replace("+","\\+");
	res=res.replace("?","\\?");
	res=res.replace(",","\\,");
	res=res.replace(".","\\.");
	res=res.replace(":","\\:");
	res=res.replace("=","\\=");
	res=res.replace("-","\\-");
	res=res.replace("!","\\!");
	res=res.replace("|","\\|");
	res=res.replace("(","\\(");
	res=res.replace(")","\\)");
	res=res.replace("[","\\[");
	res=res.replace("]","\\]");
	res=res.replace("{","\\{");
	res=res.replace("}","\\}");
	return res;
}

function igtbl_saveChangedCell(gs,rowId,cellId,value)
{
	if(typeof(gs.ChangedRows[rowId])=="undefined")
		gs.ChangedRows[rowId]=[];
	gs.ChangedRows[rowId][cellId]=true;
	gs.ChangedCells[cellId]=value;
}

function igtbl_endCustomEdit(saveChanges)
{
	var se=null;
	if(arguments.length==0)
		saveChanges=true;
	var obj=this;
	if(obj.Element)
		se=obj.Element;
	if(se!=null)
	{
		if(se.getAttribute("noOnBlur"))
			return igtbl_cancelEvent(event);
		if(se.getAttribute("editorControl"))
		{
			var oEditor=obj;
			if(!oEditor.getVisible())
				return;
			var cell=igtbl_getElementById(se.getAttribute("currentCell"));
			if(!cell)
				return;
			var gs=oEditor.webGrid;
			var cellObj=igtbl_getCellById(cell.id);
			if(typeof(oEditor.getValue())!="undefined" && saveChanges)
				cellObj.setValue(oEditor.getValue());
			if(igtbl_fireEvent(gs.Id,gs.Events.BeforeExitEditMode,"(\""+gs.Id+"\",\""+cell.id+"\")")==true)
			{
				if(!gs.exitEditCancel && !gs.insideSetActive)
				{
					gs.insideSetActive=true;
					igtbl_setActiveCell(gn,cell);
					gs.insideSetActive=false;
				}
				gs.exitEditCancel=true;
				return;
			}
			oEditor.setVisible(false);
			gs.exitEditCancel=false;
			se.removeAttribute("currentCell");
			se.removeAttribute("oldInnerText");
			gs.alignGrid();
			igtbl_fireEvent(gs.Id,gs.Events.AfterExitEditMode,"(\""+gs.Id+"\",\""+cell.id+"\");");
			gs.editorControl = null;
			se.removeAttribute("editorControl");
			if(gs.NeedPostBack)
				igtbl_doPostBack(gs.Id);
		}
	}
}

function igtbl_getLength(obj)
{
	var count=0;
	for(var item in obj)
		count++;
	return count;
}
