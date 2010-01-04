SELECT *
FROM %logdir%\ex%today%.log
TO %reportsdir%\extracted_iis_log.xml
WHERE TO_TIME(time) BETWEEN TIMESTAMP('%starttime%', 'hh:mm:ss') AND TIMESTAMP('%endtime%', 'hh:mm:ss') 