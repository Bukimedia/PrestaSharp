#!/bin/bash

mysql -u root -padmin prestashop -e "INSERT INTO ps_configuration (name, value, date_add, date_upd) VALUES ('PS_WEBSERVICE', 1, now(), now());"
mysql -u root -padmin prestashop -e "INSERT INTO ps_configuration (name, value, date_add, date_upd) VALUES ('PS_WEBSERVICE_CGI_HOST', 0, now(), now());"
mysql -u root -padmin prestashop -e "INSERT INTO ps_webservice_account (\`key\`, active) VALUES ('F9HRC3MTYYSLC98C57HCHRHAHPRFINMB', 1);"
mysql -u root -padmin prestashop -e "INSERT INTO ps_webservice_account_shop (id_webservice_account, id_shop) VALUES (1, 1);"

IFS=,
while read resource method id_webservice_account
      do
        echo "INSERT INTO ps_webservice_permission (resource, method, id_webservice_account) VALUES ('$resource', '$method', $id_webservice_account);"
done < /shell-scripts/ps_webservice_permission.csv | mysql -u root -padmin prestashop;