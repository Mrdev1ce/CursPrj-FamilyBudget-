(function () {
    'use strict';
    /**
     * @ngdoc service
     * @type provider
     * @name Camelize
     * @description
     * Util provider for converting data into camelCase and back to normal view
     */
    angular.module('App').provider('Camelize', function () {
        /**
         * @method camelize
         * Convert string to camelCase
         * @param {String} str String for camelizing
         * @returns {String} String in camelCase format
           */
        function camelize(str) {
            return str.replace(/(?:^\w|[A-Z]|\b\w)/g, function (letter, index) {
                return index === 0 ? letter.toLowerCase() : letter.toUpperCase();
            }).replace(/\s+/g, '');
        }

        /**
         * @method decamelize
         * Convert string from camelCase to normal format
         * @param {String} str String for decamelizing
         * @returns {String} String in normal format
           */
        function decamelize(str) {
            return str.replace(/(?:^\w|[A-Z])/g, function (letter, index) {
                return index === 0 ? letter.toUpperCase() : ' ' + letter;
            });
        }

        /**
         * @method mapObject
         * Assign {iterator} function to each property of {obj}
         * @param {Object} obj
         * @param {Function} iterator
         * @returns {Object|*} Returns object with properties name in camelCase
           */
        function mapObject(obj, iterator) {
            var result = {};
            if (!obj || !angular.isObject(obj)) {
                return obj;
            }
            angular.forEach(obj, function (value, key) {
                result[iterator(key)] = value;
            });

            return result;
        }

        /**
         * @method camelizeObject
         * Camelize all property's names in object
         * @param obj
         * @returns {Object|*}
           */
        function camelizeObject(obj) {
            return mapObject(obj, camelize);
        }

        /**
         * @method camelizeObject
         * Decamelize all property's names in object
         * @param obj
         * @returns {Object|*}
         */
        function decamelizeObject(obj) {
            return mapObject(obj, decamelize);
        }

        var provider = {
            camelize: camelize,
            decamelize: decamelize,
            camelizeObject: camelizeObject,
            decamelizeObject: decamelizeObject
        };

        provider.$get = function () {
            return provider;
        };

        return provider;
    });
})();