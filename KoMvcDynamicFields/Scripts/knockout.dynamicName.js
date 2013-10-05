

ko.bindingHandlers.dynamicName = {

    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {

        var allBindings = allBindingsAccessor();
        var parentSeletor = allBindings.container || "fieldset";
        var jElement = $(element);
        var parent = $(element).closest(parentSeletor);
        var parentIndex = parent.index() - 1;
        var createDynamicName = ko.utils.unwrapObservable(valueAccessor());

        if (!createDynamicName) {
            return;
        }

        // altera propriedade name
        var name = jElement.attr("name");
        var modifiedPath = name.replace(/\[\d+\]/, "[" + parentIndex + "]");
        element.name = modifiedPath;

        // altera propriedade id
        var id = jElement.attr("id");
        var modifiediD = id.replace(/\_\d+\_/, "_" + parentIndex + "_");
        element.id = modifiediD;

        // Workaround IE 6/7 issue
        // - https://github.com/SteveSanderson/knockout/issues/197
        // - http://www.matts411.com/post/setting_the_name_attribute_in_ie_dom/
        if (ko.utils.isIe6 || ko.utils.isIe7) {
            element.mergeAttributes(document.createElement("<input name='" + element.name + "'/>"), false);
        }
    }
};