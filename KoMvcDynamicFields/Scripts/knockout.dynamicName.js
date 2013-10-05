

ko.bindingHandlers.dynamicName = {

    update: function( element, valueAccessor, allBindingsAccessor, viewModel ) {

        var allBindings = allBindingsAccessor();
        var parentSeletor = allBindings.container || '.dynamic-item';
        var jElement = $( element );
        var parent = $( element ).closest( parentSeletor );
        var parentIndex = parent.index();


        var createDynamicName = ko.utils.unwrapObservable( valueAccessor() );

        if ( !createDynamicName ) {
            return;
        }

        // altera propriedade name
        var name = jElement.attr( 'name' );
        name = name.indexOf( '[0]' ) == -1 ? name + '[0]' : name; //adiciona indexação se não houver
        var modifiedPath = name.replace( /\[\d+\]/, '[' + parentIndex + ']' );
        element.name = modifiedPath;

        // altera propriedade id
        var id = jElement.attr( 'id' );
        id = id.indexOf( '_0_' ) == -1 ? name + '_0_' : id; //adiciona indexação se não houver
        var modifiediD = id.replace( /\_\d+\_/, '_' + parentIndex + '_' );
        element.id = modifiediD;

        // Workaround IE 6/7 issue
        // - https://github.com/SteveSanderson/knockout/issues/197
        // - http://www.matts411.com/post/setting_the_name_attribute_in_ie_dom/
        if ( ko.utils.isIe6 || ko.utils.isIe7 ) {
            element.mergeAttributes( document.createElement( "<input name='" + element.name + "'/>" ), false );
        }
    }
};