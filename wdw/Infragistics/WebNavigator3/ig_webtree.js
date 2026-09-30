
/* 
Infragistics Editable Tree Script 
Version 3.0.20033.8
Copyright (c) 2001-2003 Infragistics, Inc. All Rights Reserved.
Comments:
Functions marked public are for use by developers and are documented and supported.
Functions marked private are for the internal use of the UltraWebTree component.  
Functions marked private should not be used directly by developers
and are not documented for use by developers and are not supported for use by developers
*/


var igtree_IE = (document.all) ? true : false;
var igtree_treeState=[];
var igtree_indexState=[];

// public - Obtains the Tree object using its id
function igtree_getTreeById(id) 
{
	return igtree_treeState[id];;
}

// public - Obtains a Node object using its id
function igtree_getNodeById(id) 
{
	var node=igtree_getElementById(id);
	if(!node)
		return null;
	return new igtree_initNode(node);
}

// public - returns a Tree object based on a node Id 
function igtree_getTreeByNodeId(nodeId)
{
	var treeName = nodeId;
	var strArray = treeName.split("_");
	treeName = strArray[0];
	var tree = igtree_treeState[treeName];
	return tree;
}

// public - returns the tree object from a Node element
function igtree_getTreeByNode(node) {
	return igtree_getTreeByNodeId(node.id);
}

// public - Sets the selected Node for the Tree to the passed in Node.
function igtree_setSelectedNode(tn, nodeId)
{
	var ts=igtree_treeState[tn];
	if(!ts)
		return null;
		
	var node=null;
	if(nodeId != null)
		node = igtree_getElementById(nodeId);
		
	var igtree_currentNode=igtree_selectedNode(tn);

	if(node==igtree_currentNode)
		return igtree_currentNode;

	var oldNodeId = null;
	if(igtree_currentNode!=null)
		oldNodeId=igtree_currentNode.id;

	if(document.readyState == "complete") {
		if(igtree_fireEvent(tn,ts.Events.BeforeNodeSelectionChange,"(\""+tn+"\",\""+oldNodeId+"\",\""+nodeId+"\")"))
			return igtree_currentNode;
	}
	var className=igtree_getResolvedHiliteClass(tn,node);

	if(igtree_editControl != null && igtree_editControl.style.display!="none")
		if(igtree_endedit(true))
			return igtree_currentNode;

	if(igtree_currentNode!=null)
	{
		var nodeSpan = igtree_getNodeSpan(igtree_currentNode)
		var image=nodeSpan.previousSibling;
		if(image!=null && image.tagName=="IMG") {
			var unselectedImage = igtree_currentNode.getAttribute("igUnselImage");
			if(unselectedImage!=null && unselectedImage.length>0) {
				image.src=unselectedImage;
			}
		}
		nodeSpan.className=igtree_currentNode.getAttribute("igtInitClass");
	}
	if(node)
	{
		var nodeSpan=igtree_getNodeSpan(node);
		var nodeClassName=nodeSpan.className;
		if(nodeClassName!=className)
		{
			var initClass=nodeSpan.getAttribute("igtHovClass");
			if(initClass!=null)
				node.setAttribute("igtInitClass",initClass);
			else
				node.setAttribute("igtInitClass",nodeClassName);

			nodeSpan.className=className;
			
			var image=nodeSpan.previousSibling;
			if(image!=null && image.tagName=="IMG") {
				var igimg = image.getAttribute("igimg");
				if(igimg!=null && igimg.length>0) {
					var selectedImage = node.getAttribute("igSelImage");
					if(selectedImage==null || selectedImage.length==0)
						selectedImage=ts.DefaultSelectedImage;
					if(selectedImage!=null && selectedImage.length>0) {
						node.setAttribute("igUnselImage", image.src);
						image.src=selectedImage;
					}
				}
			}
		}
		ts.treeElement.setAttribute("currentNode",nodeId);
		
		var oNode = igtree_getNodeById(nodeId);
		var parent = oNode.getParent();
		while(parent != null) {
			bExp = parent.getExpanded();
			if(!bExp)
				parent.setExpanded(true);
			parent = parent.getParent();
		}
		if(igtree_IE) {
			if(nodeSpan.offsetWidth != 0 && nodeSpan.offsetHeight != 0)
				nodeSpan.focus();
		}
		igtree_updatePostField(tn, nodeId, oldNodeId);
	}
	else
		ts.treeElement.removeAttribute("currentNode");
	
	igtree_currentNode=node;

	if(document.readyState != "complete")
		return igtree_currentNode;
	igtree_fireEvent(tn,ts.Events.AfterNodeSelectionChange,"(\""+tn+"\",\""+nodeId+"\")");
	if(ts.NeedPostBack) {
		ts.NeedPostBack=false;
		__doPostBack(ts.UniqueId,"");
	}
	return igtree_currentNode;
}

// public - Browser independent way to retrieve the source element of an event
function igtree_getSrcElement(evnt)
{
	if(igtree_IE)
		return evnt.srcElement;
	else
		return evnt.target;
}

// public - Browser independent way to retrieve an element by its id
function igtree_getElementById(id)
{
	if(igtree_IE)
		return document.all[id];
	else 
		return document.getElementById(id);
}

// public - Retrieves the UniqueId on the server for the tree.
function igtree_getUniqueId(treeId)
{
	return igtree_treeState[treeId].UniqueId;
}

// public - Begins editing of a node in the tree.
function igtree_beginedit(tn,nodeId)
{
	var e = igtree_getElementById(nodeId);
	var disabled = e.getAttribute("nodeDisabled");
	if(disabled == "true")
		return;
	igtree_endedit(true);
	var src=igtree_getNodeSpan(igtree_getElementById(nodeId));
	var te = igtree_getTreeByNodeId(src.parentNode.id).treeElement;
	igtree_editControl=igtree_getEditControl(src);
	if(igtree_editControl)
	{
		if(igtree_fireEvent(tn,igtree_treeState[tn].Events.BeforeBeginNodeEdit,"(\""+tn+"\",\""+nodeId+"\")"))
			return;
		igtree_editControl.setAttribute("currentNode",nodeId);
		igtree_editControl.setAttribute("oldInnerText",src.innerText);
		if(igtree_IE)
			igtree_editControl.value=src.innerText;
		else
			igtree_editControl.value=src.innerHTML;
		igtree_editControl.style.display="";
		igtree_editControl.style.position="absolute";
		if(igtree_IE)
		{
    		igtree_editControl.style.left=igtree_fnGetLeftPos(src)-igtree_fnGetLeftPos(te)+te.scrollLeft-(te.style.borderWidth?parseInt(te.style.borderWidth,10):0);
			igtree_editControl.style.top=igtree_fnGetTopPos(src)-igtree_fnGetTopPos(te)+te.scrollTop-(te.style.borderWidth?parseInt(te.style.borderWidth,10):0);
			igtree_editControl.style.width=src.offsetWidth+25;
			if(igtree_editControl.className == null || igtree_editControl.className.length == 0) {
				igtree_editControl.style.height=src.offsetHeight;
			}
		}
		else
		{
			igtree_editControl.style.left=igtree_fnGetLeftPos(src);
			igtree_editControl.style.top=igtree_fnGetTopPos(src);
			igtree_editControl.style.width=src.offsetWidth+25;
			if(igtree_editControl.className == null || igtree_editControl.className.length == 0) {
				igtree_editControl.style.height=src.offsetHeight + 3;
			}
		}
		if(igtree_IE)
			igtree_editControl.focus();
		igtree_editControl.select();
		igtree_fireEvent(tn,igtree_treeState[tn].Events.AfterBeginNodeEdit,"(\""+tn+"\",\""+nodeId+"\")");
	}
}

// public - Ends editing of the current node
function igtree_endedit(accept)
{
	if(!igtree_editControl || igtree_editControl.style.display=="none")
		return;

	var src=igtree_getElementById(igtree_editControl.getAttribute("currentNode"));
	src=igtree_getNodeSpan(src);

	var node=igtree_getNodeById(src.parentNode.id);
	var ts = igtree_treeState[node.getTreeId()];
	if(igtree_fireEvent(node.getTreeId(),ts.Events.BeforeEndNodeEdit,"(\""+node.getTreeId()+"\",\""+node.getElement().id+"\",\""+igtree_editControl.value+"\")"))
		return true;

	if(src && accept && igtree_updateNodeText(ts, src,igtree_editControl.value))
		src.innerHTML=igtree_editControl.value;
	else if(src)
		src.innerText=igtree_editControl.getAttribute("oldInnerText");
	igtree_editControl.removeAttribute("currentNode");
	igtree_editControl.removeAttribute("oldInnerText");
	igtree_editControl.style.display="none";
	igtree_editControl=null;
	if(igtree_fireEvent(node.getTreeId(),igtree_treeState[node.getTreeId()].Events.AfterEndNodeEdit,"(\""+node.getTreeId()+"\",\""+node.getElement().id+"\")"))
		return;
	if(ts.NeedPostBack)	{
		ts.NeedPostBack=false;
		__doPostBack(ts.UniqueId,node.element.id+":Edit");
		return;
	}

}


// public - Redirects the browser to the specified Url and Target Frame
function igtree_linkTo(linkUrl, linkTarget)
{
	if(linkUrl == null || linkUrl.length == 0)
		return;
	if(linkUrl.indexOf("javascript") != -1)
		eval(linkUrl);
	else if(linkTarget != null && linkTarget!="")
	{
		if(igtree_getElementById(linkTarget) != null) 
			igtree_getElementById(linkTarget).src = linkUrl;
		else if(eval("parent.frames."+linkTarget) != null)
			eval("parent.frames."+linkTarget+".location=\""+linkUrl+"\";");
		else if(linkTarget == "_self" 
			|| linkTarget == "_parent"
			|| linkTarget == "_media"
			|| linkTarget == "_blank"
			|| linkTarget == "_search")
			window.open(linkUrl, linkTarget);
		else
			window.open(linkUrl);
	}
	else
		location.href = linkUrl;
}

// public - Marks a tree for postback to the server.  At the completion of the current event, 
// the page will be posted.
function igtree_needPostBack(tn)
{
	igtree_treeState[tn].NeedPostBack=true;
}

// public - Cancels a pending postback
function igtree_cancelPostBack(tn)
{
	igtree_treeState[tn].CancelPostBack=true;
}

// private - Initializes the tree object on the client
function igtree_initTree(treeId) 
{
	var treeElement = igtree_getElementById("T_"+treeId);
	// Create the tree object and assign it to the tree variable on the html page
	var tree = new igtree_tree(treeId, treeElement,eval("igtree_"+treeId+"_Tree"));
	treeElement.igtree = tree;
	igtree_fireEvent(treeId,tree.Events.InitializeTree,"(\""+treeId+"\");");
	tree.TreeLoaded=true;
	return tree;
}

// private - constructor for the tree object
function igtree_tree(treeId, _treeElement,treeProps)
{
	igtree_treeState[treeId]=this;
	igtree_indexState[igtree_indexState.length] = this;
	this.treeId = _treeElement.id;
	this.treeElement = _treeElement;
	this.Id = _treeElement.id;
	this.Element = _treeElement;
	this.UniqueId=treeProps[0];
	this.HiliteClass=treeProps[1];
	this.HoverClass=treeProps[2];
	this.ExpandImage=treeProps[3];
	this.CollapseImage=treeProps[4];
	this.Selectable=treeProps[5];
	this.Editable=treeProps[6];
	this.ClassicTree=treeProps[8];
	this.SingleBranchExpand=treeProps[9];
	this.LoadOnDemand=treeProps[10];
	this.RenderAnchors=treeProps[11];
	this.DefaultSelectedImage=treeProps[12];
	this.DisabledClass=treeProps[13];

	this.getSelectedNode=igtreem_getSelectedNode;
	this.setSelectedNode=igtreem_setSelectedNode;
	this.getNodeById=igtree_getNodeById;
	this.getNodes=igtree_getTreeNodes;
	this.getClientUniqueId = igtree_getClientUniqueId;

	var uniqueId = this.getClientUniqueId();
	this.Events=new igtree_events(eval("igtree_"+uniqueId+"_Events"));

	var nodeId=treeProps[14];
	if(nodeId && nodeId.length>0) {
		igtree_setSelectedNode(uniqueId, nodeId);
	}
	
	nodeId=treeProps[15];
	if(nodeId && nodeId.length>0) {
		var eNode = ig_csom.getElementById(nodeId);
		if(eNode)
			eNode.scrollIntoView(true);
	}
	this.scrolltop=treeProps[16];

	this.TreeLoaded=false;
	this.NeedPostBack=false;
	this.CancelPostBack=false;
	delete treeProps;
}

// private - initializes the client-side events for the Tree object
function igtree_events(events)
{
	this.AfterBeginNodeEdit=events[0];
	this.AfterEndNodeEdit=events[1];
	this.AfterNodeSelectionChange=events[2];
	this.AfterNodeUpdate=events[3];
	this.BeforeBeginNodeEdit=events[4];
	this.BeforeEndNodeEdit=events[5];
	this.BeforeNodeSelectionChange=events[6];
	this.BeforeNodeUpdate=events[7];
	this.NodeChecked=events[8];
	this.EditKeyDown=events[9];
	this.EditKeyUp=events[10];
	this.InitializeTree=events[11];
	this.KeyDown=events[12];
	this.KeyUp=events[13];
	this.NodeClick=events[14];
	this.NodeCollapse=events[15];
	this.NodeExpand=events[16];
	this.DemandLoad=events[17];
	delete events;
}

// private
function igtree_getNodeSpan(node)
{
	if(!node)
		return null;
	var span=node.childNodes[node.childNodes.length-1];
	while(span && span.tagName!="SPAN")
		span=span.previousSibling;
	return span;
}

// private
function igtree_getSrcNodeElement(evnt,tn)
{
	var src=igtree_getSrcElement(evnt);
	var parent = src.parentNode;
	while(src && parent && !((src.tagName=="INPUT" || src.tagName=="SPAN" || (src.tagName=="IMG" && src.getAttribute("imgType")=="exp")||(src.tagName=="IMG" && src.getAttribute("igimg")=="1"))
		&& parent.tagName=="DIV" && parent.id.length>tn.length && parent.id.substr(0,tn.length)==tn))
	{
		src=parent;
		parent=src.parentNode;
	}
	if(src && parent)
		return src;
	return null;
}

function igtree_pageUnload(){
	var count = igtree_indexState.length;
	for(i=0; i<count; i++) {
		var tree = igtree_indexState[i];
		var id = tree.Id;
		if(tree.treeElement != null)
			tree.treeElement.igtree = null;
		tree.treeElement = null;
		delete tree.Events;
		igtree_treeState[i] = null;
		delete igtree_treeState;
		delete igtree_indexState;
	}
}

if(typeof(ig_csom)!="undefined" && ig_csom.IsIE)
	ig_csom.addEventListener(window, "unload", igtree_pageUnload, true);

// private - toggles the expansion state of a node.
function igtree_toggle(tn, nodeId)
{
	var node=igtree_getNodeById(nodeId);
	var s = igtree_getElementById("M_"+nodeId);
	var ts=igtree_treeState[tn];
	
	if(!node.getEnabled()) 
		return;
	if(!s && ts.LoadOnDemand>=1) {
		node.setExpanded(true);
		return;
	}
	if(s.style.display == "none") {
		node.setExpanded(true);
	}
	else
		node.setExpanded(false);
		
	delete node;
	return;		
}

// private - Implements the Collapse() method for the Node object
function igtree_collapseNode(node) {
	var tn=node.getTreeId();
	var ts=igtree_treeState[tn];
	var s;
	s = igtree_getElementById("M_"+node.element.id);
	if(!s)
		return;
	var index = 1;
	if(ts.ClassicTree)
		index = 0;
		
	var oNode = ts.getSelectedNode();
	if(oNode != null && ts.Events.AfterNodeSelectionChange[1] == 0) {
		var parent = oNode.getParent();
		while(parent != null) {
			if(parent.element.id == node.element.id)
				node.setSelected(true);
			parent = parent.getParent();
		}
	}
	var button=node.element.childNodes[index];
	if(button.tagName!="IMG" || button.getAttribute("imgType")!="exp"){
		while (button!=null && (button.tagName!="IMG" || button.getAttribute("imgType")!="exp")) {
			button=node.element.childNodes[++index]
		}
		if(button==null)
			return;
	}
	if(igtree_fireEvent(tn,ts.Events.NodeCollapse,"(\""+tn+"\",\""+node.element.id+"\")"))
		return;
	if(ts.NeedPostBack)	{
		ts.NeedPostBack=false;
		__doPostBack(ts.UniqueId,node.element.id+":Collapse");
		return;
	}
	if(ts.ClassicTree){
		s.style.display = "none";
		button.src = button.src.replace("ig_treefminus.gif", "ig_treefplus.gif");
		button.src = button.src.replace("ig_treemminus.gif", "ig_treemplus.gif");
		button.src = button.src.replace("ig_treelminus.gif", "ig_treelplus.gif");
		button.src = button.src.replace("ig_treeominus.gif", "ig_treeoplus.gif");
	}
	else{
		image = ts.ExpandImage;
		if(image == "")
			image = "ig_treeplus.gif";
		button.src = image;
		s.style.display = "none";
	}
	igtree_updateNodeToggle(ts, s.id, false);
}

// Private - Implements the Expand() method for the Node object
function igtree_expandNode(node) {
	var tn=node.getTreeId();
	var ts=igtree_treeState[tn];
	var s;
	var index = 1;
	if(ts.ClassicTree)
		index = 0;
	var button=node.element.childNodes[index];
	if(button.tagName!="IMG" || button.getAttribute("imgType")!="exp"){
		while (button!=null && (button.tagName!="IMG" || button.getAttribute("imgType")!="exp")) {
			button=node.element.childNodes[++index]
		}
		if(button==null)
			return;
	}

	s = igtree_getElementById("M_"+node.element.id);
	if(!s) {
		var ts=igtree_treeState[tn];
		if(ts.LoadOnDemand>=1) {
				igtree_updateNodeToggle(ts, "M_"+node.element.id, true);
				if(igtree_fireEvent(tn,ts.Events.DemandLoad,"(\""+tn+"\",\""+node.element.id+"\")"))
					return;
				if(ts.NeedPostBack)	{
					__doPostBack(ts.UniqueId,node.element.id+":DemandLoad");
					return;
				}
		}
		return;
	}

	if(igtree_fireEvent(tn,ts.Events.NodeExpand,"(\""+tn+"\",\""+node.element.id+"\")"))
		return;

	if(ts.NeedPostBack){
		ts.NeedPostBack=false;
		__doPostBack(ts.UniqueId,node.element.id+":Expand");
		return;
	}

	if(ts.SingleBranchExpand) {
		var prev=node.getPrevSibling();
		while(prev != null) {
			prev.setExpanded(false);
			prev=prev.getPrevSibling();
		}
		var next=node.getNextSibling();
		while(next != null) {
			next.setExpanded(false);
			next=next.getNextSibling();
		}
	}
	
	if(ts.ClassicTree){
		s.style.display = "";
		button.src = button.src.replace("ig_treefplus.gif", "ig_treefminus.gif");
		button.src = button.src.replace("ig_treemplus.gif", "ig_treemminus.gif");
		button.src = button.src.replace("ig_treelplus.gif", "ig_treelminus.gif");
		button.src = button.src.replace("ig_treeoplus.gif", "ig_treeominus.gif");
	}
	else{
		image = ts.CollapseImage;
		if(image == "")
			image = "ig_treeminus.gif";
		button.src = image;
		s.style.display = "";
	}
	igtree_updateNodeToggle(ts, s.id, true);
}

// private - Handles checkbox clicking within the tree.
function igtree_checkboxClick(tn, nodeId, src)
{
	var ts=igtree_treeState[tn];
	var node=igtree_getNodeById(nodeId);
	if(src.checked) {
		if(igtree_fireEvent(tn,ts.Events.NodeChecked,"(\""+tn+"\",\""+nodeId+"\", true)")) {
			src.checked = false;
			return;
		}
		if(ts.NeedPostBack)	{
			__doPostBack(ts.UniqueId,nodeId+":Checked");
			return;
		}
		igtree_updateNodeCheck(ts, nodeId, true);
	}
	else {
		if(igtree_fireEvent(tn,ts.Events.NodeChecked,"(\""+tn+"\",\""+nodeId+"\", false)")) {
			src.checked = true;
			return;
		}
		if(ts.NeedPostBack)	{
			__doPostBack(ts.UniqueId,nodeId+":Unchecked");
			return;
		}
		igtree_updateNodeCheck(ts, nodeId, false);
	}
}

// private - Retrieves the resolved hover class for an item in the tree.
function igtree_getResolvedHoverClass(tn,node)
{
	if(node.getAttribute("HoverClass"))
		return node.getAttribute("HoverClass");
	return igtree_treeState[tn].HoverClass;
}

// private - Handles the mouse over event for the tree.
function igtree_mouseover(evnt,tn)
{
	if(!igtree_treeState[tn])
		return;
	var src=igtree_getSrcNodeElement(evnt,tn);
	if(!src)
		return;
	if(src.tagName!="SPAN")
		return;
	var parent = src.parentNode;

	var node=igtree_getNodeById(parent.id);
	if(!node.getEnabled())
		return;

	if(parent == igtree_selectedNode(tn))
		return;

	var className=igtree_getResolvedHoverClass(tn,parent);
	if(className=="" || src.className == className)
	    return;
	    
	var igtxt = src.getAttribute("igtxt");	
	if(igtxt!=null && igtxt.length>0) {
		src.setAttribute("igtHovClass", src.className);
		src.className = className;
	}
}

// private - Handles the mouse out event for the tree
function igtree_mouseout(evnt,tn)
{
	if(!igtree_treeState[tn])
		return;
	var src=igtree_getSrcNodeElement(evnt,tn);
	if(!src)
		return;
	if(src.tagName!="SPAN")
		return;
	var parent = src.parentNode;

	var node=igtree_getNodeById(parent.id);
	if(!node.getEnabled())
		return;

	var igtxt = src.getAttribute("igtxt");	
	if(igtxt==null || igtxt.length==0) {
		return;
	}
	if(parent != igtree_selectedNode(tn)) 
	{
		if(src.style != null) {
			prevClass =	src.getAttribute("igtHovClass");
			if(prevClass == null)
				prevClass = "";
			src.className = prevClass;
		}
	}
}

// private - Handles the right click event for the tree.
function igtree_contextmenu(evnt,tn)
{
	if(!igtree_treeState[tn])
		return;
	var ts=igtree_treeState[tn];
	var src=igtree_getSrcNodeElement(evnt,tn);
	if(!src)
		return;
	var parent = src.parentNode;
	ts.event = evnt;

	if(igtree_fireEvent(tn,ts.Events.NodeClick,"(\""+tn+"\",\""+parent.id+"\", 2)")) {
		ig_cancelEvent(evnt);
		return false;
	}
	ts.event = null;
}

// private - Retieves the resolved HiliteClass for a node in the tree.
function igtree_getResolvedHiliteClass(tn,src)
{
	if(!src)
		return "";
	if(src.getAttribute("HiliteClass"))
		return src.getAttribute("HiliteClass");
	if(igtree_treeState[tn].HiliteClass!="")
		return igtree_treeState[tn].HiliteClass;
	return tn+"HiliteClass";
}

// private - Handles the click event for nodes
function igtree_nodeclick(evnt,tn)
{
	if(!igtree_treeState[tn])
		return;
	var ts=igtree_treeState[tn];
	var src=igtree_getSrcNodeElement(evnt,tn);
	if(!src)
		return;
	var parent = src.parentNode;
	var igtxt = src.getAttribute("igtxt")!=null && src.getAttribute("igtxt").length>0;	
	var igimg = src.getAttribute("igimg")!=null && src.getAttribute("igimg").length>0;	
	var igchk = src.getAttribute("igchk")!=null && src.getAttribute("igchk").length>0;	

	igtree_lastActiveTree=tn;
	if(igtxt || igimg)
	{
		var node=igtree_getNodeById(parent.id);
		if(!node.getEnabled())
			return;

		if(ts.Selectable)
		{
			if(node.getTargetUrl()==null)
			{
				if(igtree_fireEvent(tn,ts.Events.NodeClick,"(\""+tn+"\",\""+parent.id+"\",1)"))
					return;
				if(ts.NeedPostBack)
				{
					igtree_postNodeClick(tn,parent.id,evnt);
					return;
				}
			}
			igtree_setSelectedNode(tn,parent.id);
		}			
		if(node.getTargetUrl()!="" && !ts.RenderAnchors && (!ts.Selectable || parent==igtree_selectedNode(tn)))
			igtree_linkTo(node.getTargetUrl(),node.getTargetFrame());
	}
	else if(src.tagName=="IMG")
		igtree_toggle(tn,parent.id);
	else if(igchk) {
		igtree_checkboxClick(tn, parent.id, src);
	}
}

var igtree_treeName;
var igtree_nodeId;
var igtree_postCanceled = false;

var igtree_clickCounter = 0;

// private - Handles posting node click events to the server
function igtree_postNodeClick(treeName, nodeId, evnt)
{
	igtree_treeName = treeName;
	igtree_nodeId = nodeId;
	var src;
	if(evnt == null)
		evnt = window.event;
	src = igtree_getElementById(nodeId);
	igtree_clickCounter++;
	if(igtree_clickCounter == 1)
		setTimeout('igtree_onTimerPostNodeClick()', 300);
}

// private - Posts node click events on time expiration
function igtree_onTimerPostNodeClick() 
{
	igtree_updatePostField(igtree_treeName, igtree_nodeId, null); 
	if(igtree_postCanceled == false) {
		var ts = igtree_getTreeById(igtree_treeName);	
		ts.NeedPostBack=false;
		__doPostBack(igtree_getUniqueId(igtree_treeName), igtree_nodeId+":Clicked");
	}
	igtree_postCanceled = false;
	igtree_clickCounter = 0;
}

// private - Handles the scrolling of the tree
function igtree_onscroll(src)
{
	var treeName = src;
	var ts = igtree_getTreeById(src);	
	var formControl = igtree_getElementById(igtree_getUniqueId(treeName));
	if(formControl == null)
		return;
	var treeState = formControl.value;

	var index = treeState.search("Tree:Scrl");
	if(index >= 0)
	{
		var reg = /Tree:Scrl=\d+<%;/;
		treeState = treeState.replace(reg, "");
	}
	var treeControl = igtree_getElementById("T_" + treeName);
	var scrollVal = treeControl.scrollTop;
	treeState += "Tree:Scrl=" + scrollVal + "<%;";
	formControl.value = treeState;
	return true;
}
	
// private - Updates the PostBackData field
function igtree_updatePostField(treeName, nodeId, oldNodeId)
{
	var formControl = igtree_getElementById(igtree_getUniqueId(treeName));
	if(!formControl)
		return;
	var treeState = formControl.value;
	if(oldNodeId && treeState.search(oldNodeId + ":Clck<%;")>=0)
		treeState=treeState.replace(oldNodeId + ":Clck<%;", nodeId + ":Clck<%;");
	else
		treeState += nodeId + ":Clck<%;";
	formControl.value = treeState;
}

// private - Handles the double click event for a node
function igtree_dblclick(evnt,tn)
{
	var src=igtree_getSrcNodeElement(evnt,tn);
	if(!src)
		return;
	var ts=igtree_treeState[tn];
	var parent = src.parentNode;
	var igtxt = src.getAttribute("igtxt")!=null && src.getAttribute("igtxt").length>0;	
	var igimg = src.getAttribute("igimg")!=null && src.getAttribute("igimg").length>0;	
	if(igtxt && ts.Editable)
	{
		igtree_postCanceled = true;
		igtree_beginedit(tn,src.parentNode.id);
		return;
	}
	if(igimg || igtxt) {
		var node=igtree_getNodeById(parent.id);
		if(node.getFirstChild() != null || ts.LoadOnDemand>=1) {
			igtree_toggle(tn,parent.id);
		}
	}
}

var igtree_editControl = null;
// private - Retrieves the in-place edit control for an editable tree
function igtree_getEditControl(src)
{
	var strArray;
	if(!src)
		return null;
	if(igtree_IE)
		strArray = src.parentElement.id.split("_");
	else
		strArray = src.parentNode.id.split("_");
	var treeName = strArray[0];
	return igtree_getElementById(treeName+"_tb");
}

// private - Handles mouse clicks within the edit control
function igtree_editClickHandler()
{
	event.cancelBubble = true;
}

// private - Handles selection events for the tree
function igtree_selectStart()
{
	if(window.event.srcElement.tagName == "INPUT")
		return;
	window.event.cancelBubble = true; 
	window.event.returnValue = false; 
	return false;	
}

// private - Updates internal buffer for edited node data
function igtree_updateNodeText(ts, src, newText)
{
	var nodeId;
	if(igtree_IE)
		nodeId = src.parentElement.id;
	else
		nodeId = src.parentNode.id;
	var treeName = nodeId;
	var strArray = treeName.split("_");
	treeName = strArray[0];
	if(igtree_fireEvent(treeName,ts.Events.BeforeNodeUpdate,"(\""+treeName+"\",\""+nodeId+"\",\""+newText+"\")"))
		return;
	var formControl = igtree_getElementById(ts.UniqueId);
	if(formControl == null)
		return;
	var treeState = formControl.value;
	treeState += nodeId + ":Edit=" + newText + "<%;";
	formControl.value = treeState;
	igtree_fireEvent(treeName,ts.Events.AfterNodeUpdate,"(\""+treeName+"\",\""+nodeId+"\")");
	if(ts.NeedPostBack)
		__doPostBack(ts.UniqueId,"");
	return true;
}

// private - Updates internal buffer for node expansion/collapse data
function igtree_updateNodeToggle(ts, src, bExpanded)
{
	var nodeId = src;
	var treeName = nodeId;
	nodeId = nodeId.replace("M_", "");
	
	var strArray = treeName.split("_");
	treeName = strArray[1];
	nodeId = nodeId.replace(treeName, "t");
	var formControl = igtree_getElementById(ts.UniqueId);
	if(formControl == null) 
		return;
	var treeState = formControl.value;
	var newValue;
	var oldValue;
	if(bExpanded)
	{
		oldValue = "0";
		newValue = "1";
	}
	else
	{
		oldValue = "1";
		newValue = "0";
	}
	var oldString1 = nodeId + ":Togl=" + oldValue + "<%;";
	var newString = nodeId + ":Togl=" + newValue + "<%;";
	if(treeState.search(oldString1) >= 0)
		treeState = treeState.replace(oldString1, newString);
	else {
		var oldString2 = nodeId + ":Togl=" + newValue + "<%;";
		if(treeState.search(oldString2) >= 0) 
			treeState = treeState.replace(oldString2, newString);
		else
			treeState += newString;
	}
	formControl.value = treeState; 
}
   
// private - Updates internal buffer for node checked status
function igtree_updateNodeCheck(ts, src, bChecked){
	var nodeId = src;
	var treeName = nodeId;
	var strArray = treeName.split("_");
	treeName = strArray[0];
	nodeId = nodeId.replace(treeName, "t");
	var formControl = igtree_getElementById(ts.UniqueId);
	if(formControl == null)
		return;
	var treeState = formControl.value;

	var newValue;
	var oldValue;
	if(bChecked)
	{
		oldValue = "0";
		newValue = "1";
	}
	else
	{
		oldValue = "1";
		newValue = "0";
	}
	var oldString1 = nodeId + ":Chck=" + oldValue + "<%;";
	var newString = nodeId + ":Chck=" + newValue + "<%;";
	if(treeState.search(oldString1) >= 0)
		treeState = treeState.replace(oldString1, newString);
	else {
		var oldString2 = nodeId + ":Chck=" + newValue + "<%;";
		if(treeState.search(oldString2) >= 0)
			treeState = treeState.replace(oldString2, newString);
		else
			treeState += newString;
	}
	formControl.value = treeState; 
}

// private - Handles key down events
function igtree_keydown(evnt, treeID)
{
	var ts=igtree_treeState[treeID];
	var tree=ts.treeElement;
	var processed=false;
	var igtree_currentNode = igtree_selectedNode(treeID);
	if(igtree_fireEvent(treeID,ts.Events.KeyDown,"(\""+treeID+"\","+evnt.keyCode+")"))
		return;
	if(evnt.keyCode == 113)
	{  // F2
		if(igtree_currentNode != null)
		{
			processed=true;
			if(ts.Editable)
				igtree_beginedit(treeID,igtree_currentNode.id);
		}
	}
	if(evnt.keyCode == 107 || evnt.keyCode == 109 || evnt.keyCode == 37 || evnt.keyCode == 39)
	{ // plus/minus key
		if(igtree_currentNode == null)
			return;
		var ns=igtree_getElementById("M_"+igtree_currentNode.id);
		if(!ns && ts.LoadOnDemand>0) {
			if(evnt.keyCode==107 || evnt.keyCode==39)
				igtree_toggle(treeID,igtree_currentNode.id);
			processed=true;
		}
		else
		if(ns)
		{
			var toggle=((evnt.keyCode == 107 || evnt.keyCode == 39) && ns.style.display=="none" || (evnt.keyCode == 109 || evnt.keyCode == 37) && ns.style.display=="");
			if(toggle)
				igtree_toggle(treeID,igtree_currentNode.id);
			processed=true;
		}
	}
	if(evnt.keyCode == 35)
	{ // end key
		if(igtree_currentNode)
		{
			var last = igtree_lastNode(treeID);
			if(last)
			{
				last=igtree_setSelectedNode(treeID,last.id);
				igtree_scrollToView(tree,last);
				processed=true;
			}
		}
	}
	if(evnt.keyCode == 36)
	{ // home key
		if(igtree_currentNode)
		{
			var first = igtree_firstNode(treeID);
			if(first)
			{
				first=igtree_setSelectedNode(treeID,first.id);
				igtree_scrollToView(tree,first);
				processed=true;
			}
		}
	}
	if(evnt.keyCode == 38)
	{ // up arrow
		if(igtree_currentNode)
		{
			var sibling = igtree_prevVisibleNode(treeID,igtree_currentNode);
			if(sibling)
			{
				sibling=igtree_setSelectedNode(treeID,sibling.id);
				igtree_scrollToView(tree,sibling);
				processed=true;
			}
		}
	}
	if(evnt.keyCode == 40)
	{ // down arrow
		if(igtree_currentNode)
		{
			var sibling = igtree_nextVisibleNode(treeID,igtree_currentNode);
			if(sibling)
			{
				sibling=igtree_setSelectedNode(treeID,sibling.id);
				igtree_scrollToView(tree,sibling);
				processed=true;
			}
		}
	}
	if(processed)
	{
		evnt.cancelBabble=true;
		evnt.returnValue=false;
		return false;
	}
}

// private - Handles key up events
function igtree_keyup(evnt, tn)
{
	if(igtree_fireEvent(tn,igtree_treeState[tn].Events.KeyUp,"(\""+tn+"\","+evnt.keyCode+")"))
		return;
}

// private
function igtree_nextSibling(tn,node,branch) {
	var ts=igtree_treeState[tn];
	var sibling;
	if(!node)
	{
		var tree=ts.treeElement;
		var first=tree.childNodes[0].childNodes[0];
		while(first && first.tagName!="DIV")
			first=first.nextSibling;
		if(!first)
			return null;
		sibling=first;
		while(sibling && (sibling.tagName!="DIV" || sibling.id.substr(0,2)=="M_"))
			sibling=sibling.nextSibling;
		return sibling;
	}
	else
		sibling = node.nextSibling;
	while(sibling && (sibling.tagName!="DIV" || sibling.style.display=="none" || branch && sibling.id.substr(0,2)=="M_"))
		sibling=sibling.nextSibling;
	if(!sibling && branch)
		return null;
	var parentNode = node.parentNode;
	while(!sibling && parentNode && parentNode.id.substr(0,2)=="M_")
	{
		sibling=parentNode.nextSibling;
		while(sibling && (sibling.tagName!="DIV" || sibling.style.display=="none"))
			sibling=sibling.nextSibling;
		parentNode=parentNode.parentNode;
	}
	if(sibling && sibling.id.substr(0,2)=="M_")
		sibling=sibling.childNodes[0];
	while(sibling && (sibling.tagName!="DIV" || sibling.style.display=="none"))
		sibling=sibling.nextSibling;
	return sibling;
}

function igtree_prevSibling(tn,node,branch)
{
	var ts=igtree_treeState[tn];
	var sibling;
	if(!node)
	{
		var tree=ts.treeElement;
		var last=tree.childNodes[0].childNodes[tree.childNodes[0].childNodes.length-1];
		while(last && last.tagName!="DIV")
			last=last.previousSibling;
		if(!last)
			return null;
		sibling=last;
		while(sibling && (sibling.tagName!="DIV" || sibling.id.substr(0,2)=="M_"))
			sibling=sibling.previousSibling;
		return sibling;
	}
	else
		sibling = node.previousSibling;
	while(sibling && (sibling.tagName!="DIV" || sibling.style.display=="none" || branch && sibling.id.substr(0,2)=="M_"))
		sibling=sibling.previousSibling;
	if(!sibling && branch)
		return null;
	var parentNode = node.parentNode;
	while(!sibling && parentNode && parentNode.id.substr(0,2)=="M_")
	{
		sibling=parentNode.previousSibling;
		while(sibling && (sibling.tagName!="DIV" || sibling.style.display=="none"))
			sibling=sibling.previousSibling;
		parentNode=parentNode.parentNode;
	}
	while(sibling && sibling.id.substr(0,2)=="M_")
	{
		sibling=sibling.childNodes[sibling.childNodes.length-1];
		while(sibling && (sibling.tagName!="DIV" || sibling.style.display=="none"))
			sibling=sibling.previousSibling;
	}
	return sibling;
}

function igtree_fnGetLeftPos(e) 
{
    x = e.offsetLeft;
    tmpE = e.offsetParent;
    while (tmpE != null) 
    {
        x += tmpE.offsetLeft;
        if(tmpE.tagName=="DIV" && tmpE.style.borderLeftWidth)
	        x += parseInt(tmpE.style.borderLeftWidth);
        if(igtree_IE && tmpE.tagName!="BODY") {
			x-=tmpE.scrollLeft;
	    }
        tmpE = tmpE.offsetParent;
    }
    return x;
}

// Returns top position of some element
function igtree_fnGetTopPos(e) 
{
    y = e.offsetTop;
    tmpE = e.offsetParent;
    while (tmpE != null) 
    {
        y += tmpE.offsetTop;
        if(tmpE.tagName=="DIV" && tmpE.style.borderTopWidth)
	        y += parseInt(tmpE.style.borderTopWidth);
        if(igtree_IE && tmpE.tagName!="BODY")
			y-=tmpE.scrollTop;
        tmpE = tmpE.offsetParent;
    }
    return y;
}

function igtree_scrollToView(parent,child)
{
	if(parent.scrollWidth<=parent.offsetWidth && parent.scrollHeight<=parent.offsetHeight)
		return;
	var childLeft=igtree_fnGetLeftPos(child);
	var parentLeft=igtree_fnGetLeftPos(parent);
	var childTop=igtree_fnGetTopPos(child);
	var parentTop=igtree_fnGetTopPos(parent);
	var childRight=childLeft+child.offsetWidth;
	var parentRight=parentLeft+parent.offsetWidth;
	var childBottom=childTop+child.offsetHeight;
	var parentBottom=parentTop+parent.offsetHeight;
	var hsw=(parent.scrollWidth>parent.offsetWidth?18:0);
	var vsw=(parent.scrollWidth>parent.offsetWidth || parent.scrollHeight>parent.offsetHeight?18:0);
	if(childRight>parentRight-vsw && childLeft-(childRight-parentRight)>parentLeft)
		parent.scrollLeft+=childRight-parentRight+vsw;
	if(childBottom>parentBottom-hsw && childTop-(parentTop-childTop)>parentTop)
		parent.scrollTop+=childBottom-parentBottom+hsw;
	if(childLeft<parentLeft)
		parent.scrollLeft-=parentLeft-childLeft;
	if(childTop<parentTop)
		parent.scrollTop-=parentTop-childTop;
}

function igtree_editKeyDown(evnt,tn)
{
	if(!igtree_editControl)
		return;
	var src=igtree_getElementById(igtree_editControl.getAttribute("currentNode"));
	var node=igtree_getNodeById(src.id);
	src=igtree_getNodeSpan(src);
	if(igtree_fireEvent(tn,igtree_treeState[tn].Events.EditKeyDown,"(\""+tn+"\",\""+node.getElement().id+"\","+evnt.keyCode+")")){
		evnt.cancelBubble = true;
		evnt.returnValue = false;
		return;
	}
	if(igtree_IE)
	{
		evnt.cancelBubble=true;
		if(evnt.keyCode==13)
		{
			event.returnValue=false;
			igtree_endedit(true);
			return false;
		}
		else if(evnt.keyCode==27)
			igtree_endedit(false);
	}
	else
	{
		if(evnt.keyCode==13)
		{
			evnt.stopPropagation();
			igtree_endedit(true);
			return false;
		}
		else if(evnt.keyCode==27)
			igtree_endedit(false);
	}
}

function igtree_editKeyUp(evnt,tn)
{
	if(!igtree_editControl)
		return;
	var src=igtree_getElementById(igtree_editControl.getAttribute("currentNode"));
	var node=igtree_getNodeById(src.id);
	src=igtree_getNodeSpan(src);
	if(igtree_fireEvent(tn,igtree_treeState[tn].Events.EditKeyUp,"(\""+tn+"\",\""+node.getElement().id+"\","+evnt.keyCode+")"))
		return;
	if(igtree_IE)
		evnt.cancelBubble=true;
		
}

// private - Initializes a Node object with properties and method references
function igtree_initNode(node)
{
	this.element=node;
	this.Element=node;
	this.Id = node.id;
	this.getTreeId=igtree_getTreeId;
	this.getElement=igtree_getElement;
	this.getText=igtree_getText;
	this.setText=igtree_setText;
	this.getTag=igtree_getTag;
	this.setTag=igtree_setTag;
	this.getDataKey=igtree_getDataKey;
	this.getHiliteClass=igtree_getHiliteClass;
	this.setHiliteClass=igtree_setHiliteClass;
	this.getHoverClass=igtree_getHoverClass;
	this.setHoverClass=igtree_setHoverClass;
	this.getEnabled=igtree_getEnabled;
	this.setEnabled=igtree_setEnabled;
	this.getTargetFrame=igtree_getTargetFrame;
	this.setTargetFrame=igtree_setTargetFrame;
	this.getTargetUrl=igtree_getTargetUrl;
	this.setTargetUrl=igtree_setTargetUrl;
	this.hasChildren=igtree_hasChildren;
	
	this.getExpanded=igtree_getExpanded;
	this.setExpanded=igtree_setExpanded;
	this.getSelected=igtree_getSelected;
	this.setSelected=igtree_setSelected;
	this.getChecked=igtree_getChecked;
	this.setChecked=igtree_setChecked;
	this.hasCheckbox=igtree_hasCheckbox;
	
	this.getNextSibling=igtree_getNodeNextSibling;
	this.getPrevSibling=igtree_getNodePrevSibling;
	this.getFirstChild=igtree_getNodeFirstChild;
	this.getParent=igtree_getNodeParent;
	this.getChildNodes=igtree_getChildNodes;
	this.getLevel = function () {
		var nodeName=this.element.id.split("_")
		if(nodeName.length>1)
		{
			return nodeName.length - 2;			
		}
	}
	this.getIndex = function () {
		var index=0;
		var nodeName=this.element.id.split("_")
		if(nodeName.length>1)
		{
			index = parseInt(nodeName[nodeName.length-1]);
			return index-1;
		}
	}
}

function igtree_getElement() {
	return this.element;
}
function igtree_getTreeId() {
	var treeName = this.element.id;
	var strArray = treeName.split("_");
	treeName = strArray[0];
	return treeName;
}
function igtree_getText() {
	var i;
	for(i=0; i < this.element.childNodes.length; i++) {
		var attrib = this.element.childNodes[i].getAttribute("igTxt");
		if(attrib=="1")
			return this.element.childNodes[i].innerHTML;
	}
}
function igtree_setText(text) {
	var i;
	for(i=0; i < this.element.childNodes.length; i++) {
		var attrib = this.element.childNodes[i].getAttribute("igTxt");
		if(attrib=="1") {
			this.element.childNodes[i].innerHTML=text;
			var ts = igtree_getTreeById(this.getTreeId());	
			igtree_updateNodeText(ts, this.element.childNodes[i], text)
		}
	}
}
function igtree_getTag() {
	var a = this.element.getAttribute("igTag");
	if(a!=null && a.length>0)
		return a;
	else
		return null;
}
function igtree_setTag(text) {
	this.element.setAttribute("igTag", text);
}
function igtree_getDataKey() {
	var a = this.element.getAttribute("igDataKey");
	if(a!=null && a.length>0)
		return a;
	else
		return null;
}
function igtree_getHiliteClass() {
	return this.element.getAttribute("HiliteClass")
}
function igtree_setHiliteClass(hiliteClass) {
	this.element.setAttribute("HiliteClass", hiliteClass)
}
function igtree_getHoverClass() {
	return this.element.getAttribute("HoverClass")
}
function igtree_setHoverClass(hoverClass) {
	this.element.setAttribute("HoverClass", hoverClass)
}
function igtree_getEnabled() {
	return(this.element.getAttribute("nodeDisabled")?false:true);
}
function igtree_setEnabled(enabled) {
	var i;
	var nodeSpan = null;
	for(i=0; i < this.element.childNodes.length; i++) {
		var attrib = this.element.childNodes[i].getAttribute("igTxt");
		if(attrib=="1")
			nodeSpan = this.element.childNodes[i];
	}
	if(nodeSpan != null) {
		if(enabled == true) {
			this.element.removeAttribute("nodeDisabled");
			var oldClass = nodeSpan.getAttribute("oldEnabledClass");
			if(oldClass != null && oldClass.length > 0) {
				nodeSpan.className=oldClass;
				nodeSpan.removeAttribute("oldEnabledClass");
			}
		}
		else {
			var ts = igtree_getTreeById(this.getTreeId());
			var disabledClass = ts.DisabledClass;
			this.element.setAttribute("nodeDisabled", "1");
			var oldClass = nodeSpan.className;
			nodeSpan.className=disabledClass;
			nodeSpan.setAttribute("oldEnabledClass", oldClass);
			this.element.removeAttribute("igtInitClass");
		}
	}
}
function igtree_getTargetFrame() {
	
	return(this.element.getAttribute("igFrame")?this.element.getAttribute("igFrame"):"");
}
function igtree_setTargetFrame(frame) {
	this.element.setAttribute("igFrame", frame)
}
function igtree_getTargetUrl() {
	var url = this.element.getAttribute("igUrl");
	if(url != null && url.length > 0)
		return url;
	else
		return null;
}
function igtree_setTargetUrl(url) {
	this.element.setAttribute("igUrl", url)
}
function igtree_setChecked(bChecked, bFireCSOMEvent) {
	var node = this.element;
	var ts = igtree_getTreeByNodeId(node.id);	
	var index=1;
	var count=node.childNodes.length;
	for(index=1;index<count;index++) {
		var chk = node.childNodes[index].getAttribute("igChk");
		if(chk!=null && chk.length>0)
			break;
	}
	if(index >= count)
		return;
	eCheck = node.childNodes[index];
	if(bChecked==false) {
		eCheck.checked=false;
	}
	else {
		eCheck.checked=true;
	}
	if(bFireCSOMEvent!=false) {
		var tn = this.getTreeId();
		var nodeId = this.Id;
		if(igtree_fireEvent(tn,ts.Events.NodeChecked,"(\""+tn+"\",\""+nodeId+"\", eCheck.checked)")) {
			eCheck.checked = oldValue;
			return;
		}
	}	
	igtree_updateNodeCheck(ts, this.element.id, bChecked);
}

function igtree_getChecked() {
	var node = this.element;
	var index=1;
	var count=node.childNodes.length;
	for(index=1;index<count;index++) {
		var chk = node.childNodes[index].getAttribute("igChk");
		if(chk!=null && chk.length>0)
			break;
	}
	return this.element.childNodes[index].checked;
}
function igtree_hasCheckbox() {
	var index;
	for(index=1;index<this.element.childNodes.length;index++) {
		var chk = this.element.childNodes[index].getAttribute("igChk");
		if(chk!=null && chk.length>0)
			return true;
	}
	return false;
}
function igtree_hasChildren() {
	var expEl=igtree_getElementById("M_"+this.element.id);
	return expEl!=null;
}
function igtree_getExpanded() {
	var expEl=igtree_getElementById("M_"+this.element.id);
	if(expEl != null)
		return(expEl.style.display!="none");
	else
		return false;
}
function igtree_setExpanded(expand) {
	if(expand == true)
		igtree_expandNode(this);
	else
		igtree_collapseNode(this);
}
function igtree_getSelected() {
	var treeName = this.element.id;
	var strArray = treeName.split("_");
	treeName = strArray[0];
	return (this.Element==igtree_selectedNode(treeName));
}
function igtree_setSelected(bSelect) {
	var treeName = this.element.id;
	var strArray = treeName.split("_");
	treeName = strArray[0];
	if(bSelect) {
		igtree_setSelectedNode(treeName, this.element.id)
	}
	else {
		if(this.Element==igtree_selectedNode(treeName))
			igtree_setSelectedNode(treeName, null)
	}
}

// private - Initializes an event
function igtree_fireEvent(tn,eventObj,eventString)
{
	var ts=igtree_treeState[tn];
	var result=false;
	if(eventObj[0]!="")
		result=eval(eventObj[0]+eventString);
	if(ts.TreeLoaded && result!=true && eventObj[1]==1 && !ts.CancelPostBack)
		igtree_needPostBack(tn);
	ts.CancelPostBack=false;
	return result;
}

// private
var igtree_lastActiveTree="";
if(!igtree_IE)
	if(window.addEventListener)
		window.addEventListener('keydown',igtree_windowKeyDown,false);

// private
function igtree_windowKeyDown(evnt)
{
	if(igtree_lastActiveTree!="" && evnt.keyCode!=13)
		if(igtree_onKeyDown(evnt,igtree_lastActiveTree)==true)
		{
			evnt.stopPropagation();
			evnt.preventDefault();
		}
}

// private
function igtree_initEvent(se)
{
	this.target=se;
}

// public - Returns the selected Node for the Tree 
function igtree_selectedNode(tn) 
{
	var cnId = igtree_treeState[tn].treeElement.getAttribute("currentNode");
	if(cnId)
		return igtree_getElementById(cnId);
	return null;
}

// private - Implements the setSelectedNode method for the tree
function igtreem_setSelectedNode(node)
{
	var uniqueId = this.getClientUniqueId();
	var id=null;
	if(node!=null)
		id=node.Id;
	igtree_setSelectedNode(uniqueId, id);
}

// private - Implements the getSelectedNode method for the tree
function igtreem_getSelectedNode()
{
	var uniqueId = this.getClientUniqueId();
	var node=igtree_selectedNode(uniqueId);
	if(node)
		return igtree_getNodeById(node.id);
	return null;
}

// private
function igtree_getClientUniqueId() {
	var u = this.UniqueId.replace(/:/gi, "");
	u = u.replace(/_/gi, "");
	return u;
}

// private
function igtree_getTreeNodes()
{
	var nodeAr=new Array();
	var nodeCount=0;
	var uniqueId = this.getClientUniqueId();	
	var node=igtree_nextSibling(uniqueId,null);
	while(node)
	{
		nodeAr[nodeCount++]=igtree_getNodeById(node.id);
		node=igtree_nextSibling(uniqueId,node);
	}
	return nodeAr;
}

// private - Implements getNextSibling for the Node object
function igtree_getNodeNextSibling()
{
	var node=igtree_nextSibling(this.getTreeId(),this.element,true);
	if(node)
		node=igtree_getNodeById(node.id);
	return node;
}

// private - Implements GetPrevSibling for the Node object
function igtree_getNodePrevSibling()
{
	var node=igtree_prevSibling(this.getTreeId(),this.element,true);
	if(node)
		node=igtree_getNodeById(node.id);
	return node;
}

// private - Implements FirstChild for the Node object
function igtree_getNodeFirstChild()
{
	var node=null;
	if(this.hasChildren())
		node=igtree_getNodeById(this.element.id+"_1");
	return node;
}

// private - Implements the Parent property for the Node object
function igtree_getNodeParent()
{
	var node=null;
	var nodeName=this.element.id.split("_")
	if(nodeName.length>2)
	{
		var parentName=this.element.id.substr(0,this.element.id.length-nodeName[nodeName.length-1].length-1);
		node=igtree_getNodeById(parentName);
	}
	return node;
}

// private - Implements Nodes collection property for the Node object
function igtree_getChildNodes()
{
	var nodeAr=new Array();
	var nodeCount=0;
	var node=this.getFirstChild();
	while(node)
	{
		nodeAr[nodeCount++]=node;
		node=node.getNextSibling();
	}
	return nodeAr;
}

// private
function igtree_firstNode(tn) 
{
	return igtree_nextSibling(tn,null);
}

// private
function igtree_lastNode(tn) 
{
	return igtree_prevSibling(tn,null);
}

// private
function igtree_nextNode(tn,node) 
{
	return igtree_nextSibling(tn,node,true);
}

// private
function igtree_prevNode(tn,node) 
{
	return igtree_prevSibling(tn,node,true);
}

// private
function igtree_nextVisibleNode(tn,node) 
{
	return igtree_nextSibling(tn,node);
}

// private
function igtree_prevVisibleNode(tn,node) 
{
	return igtree_prevSibling(tn,node);
}

