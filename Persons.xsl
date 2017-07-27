<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <body>
        <h2>Display Information of all the people in the Xml file</h2>
        <table border="1">
          <tr bgcolor="#00FA9A">
            <th>First Name </th>
            <th>Last Name </th>
            <th>Id</th>
            <th>Password</th>
            <th>Phone: Work</th>
            <th>Phone: Cell</th>
            <th>Category</th>
          </tr>
          <xsl:for-each select="Persons/Person">
            <tr>
              <xsl:choose>
                <xsl:when test="Name">
                  <xsl:for-each select="Name">
                    <td rowspan="2">
                      <xsl:value-of select="First"/>
                    </td>
                    <td rowspan="2">
                      <xsl:value-of select="Last"/>
                    </td>
                  </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                  <td rowspan="2">

                  </td>
                  <td rowspan="2">

                  </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test="Credential">
                  <xsl:for-each select="Credential">
                    <td rowspan="2">
                      <xsl:value-of select="Id"/>
                    </td>
                    <td>
                      <xsl:value-of select="Password"/>
                    </td>
                  </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                  <td rowspan="2">

                  </td>
                  <td>

                  </td>
                </xsl:otherwise>
              </xsl:choose>
                <xsl:choose>
                  <xsl:when test="Phone">
                    <xsl:for-each select="Phone">
                      <td rowspan="2">
                        <xsl:value-of select="Work"/>
                      </td>
                      <td>
                        <xsl:value-of select="Cell"/>
                      </td>
                    </xsl:for-each>
                  </xsl:when>
                  <xsl:otherwise>
                    <td rowspan="2">

                    </td>
                    <td>

                    </td>
                  </xsl:otherwise>
                  </xsl:choose>
                  <td rowspan="2">
                    <xsl:value-of select="Category"/>
                  </td>
                </tr>
            <tr>
              <xsl:choose>
                <xsl:when test="Credential">
              <xsl:for-each select="Credential">
                <td>
                  Encryption: <xsl:value-of select="Password/@Encryption"/>
                </td>
              </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                  <td>

                  </td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test="Phone">
              <xsl:for-each select="Phone">
                <td>
                  Provider: <xsl:value-of select="Cell/@Provider" />
                </td>
              </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                  <td>

                  </td>
                </xsl:otherwise>
              </xsl:choose>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>