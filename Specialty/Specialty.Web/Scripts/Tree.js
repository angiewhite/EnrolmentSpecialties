function tree(id, url) {
	var element = document.getElementById(id)
	function hasClass(elem, className) {
		return new RegExp("(^|\\s)"+className+"(\\s|$)").test(elem.className)
	}

	function toggleNode(node) {
		var newClass = hasClass(node, 'ExpandOpen') ? 'ExpandClosed' : 'ExpandOpen'
		var re =  /(^|\s)(ExpandOpen|ExpandClosed)(\s|$)/
		node.className = node.className.replace(re, '$1'+newClass+'$3')
	}

	function load(node) {

		function showLoading(on) {
			var expand = node.getElementsByTagName('DIV')[0]
			expand.className = on ? 'ExpandLoading' : 'Expand'
		}


		function onSuccess(data) {
			if (!data.errcode) {
				onLoaded(data)
				showLoading(false)
			} else {
				showLoading(false)
				onLoadError(data)
			}
		}


		function onAjaxError(xhr, status){
			showLoading(false)
			var errinfo = { errcode: status }
			if (xhr.status != 200) {
				errinfo.message = xhr.statusText
			} else {
				errinfo.message = 'Invalid data from the server'
			}
			onLoadError(errinfo)
		}

        //here
		function onLoaded(data) {

			for(var i = 0; i < data.length; i++) {
				var child = data[i]
				var li = document.createElement('LI')
				li.id = child.id

				li.className = "Node Expand" + (child.count != 0 ? 'Closed' : 'Leaf')
				if (i == data.length-1) li.className += ' IsLast'

                li.innerHTML = '<div class="Expand"></div><input type="checkbox"/><div class="Content">' + child.fullName + " (" + child.shortName + ")" + '</div>'
				if (child.count != 0) {
					li.innerHTML += '<ul class="Container"></ul>'
				}
				node.getElementsByTagName('UL')[0].appendChild(li)
            }
            var object = $(node.getElementsByTagName("UL")[0])
            object.find("input").prop("checked", $(node.getElementsByTagName("input")[0]).prop("checked"))
			node.isLoaded = true
            toggleNode(node)
		}

		function onLoadError(error) {
			var msg = "Error "+error.errcode
			if (error.message) msg = msg + ' :'+error.message
			alert(msg)
		}


		showLoading(true)

		$.ajax({
            url: url,
            data: { nodeId: node.id },
			dataType: "json",
			success: onSuccess,
			error: onAjaxError,
			cache: false
        })
	}
    
    element.onclick = function (event) {
		event = event || window.event
        var clickedElem = event.target
        
		if (!hasClass(clickedElem, 'Expand')) {
			return 
		}
        
		var node = clickedElem.parentNode
		if (hasClass(node, 'ExpandLeaf')) {
			return 
		}

		if (node.isLoaded || node.getElementsByTagName('LI').length) {
			toggleNode(node)
			return
		}


		if (node.getElementsByTagName('LI').length) {
			toggleNode(node)
			return
		}

		load(node)
    }
}

function checkParents(input) {
    if (!input.parent().hasClass("IsRoot")) {
        var parent = findParent(input, "input")
        if (!input.prop("checked") && parent.parent().find("input:checked").length != 1) {
            return
        }
        parent.prop("checked", input.prop("checked"))
        checkParents(parent)
    }
    return;
}

function findParent(element, type) {
    var parent
    element.parent().parent().siblings().each(function () {
        if ($(this).is(type)) parent = $(this)
    })
    return parent
}